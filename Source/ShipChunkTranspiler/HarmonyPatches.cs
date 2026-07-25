using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ShipChunkDrop_Transpiler;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("mehni.rimworld.shipchunks.main").Patch(
            AccessTools.Method(typeof(IncidentWorker_ShipChunkDrop), "SpawnChunk"), null, null,
            new HarmonyMethod(typeof(HarmonyPatches), nameof(IncidentWorker_ShipChunkDrop_SpawnChunk_Transpiler)));
    }

    public static IEnumerable<CodeInstruction> IncidentWorker_ShipChunkDrop_SpawnChunk_Transpiler(
        IEnumerable<CodeInstruction> instructions)
    {
        var targetField = AccessTools.Field(typeof(ThingDefOf), nameof(ThingDefOf.ShipChunk));
        var chunkSelector = AccessTools.Method(typeof(HarmonyPatches), nameof(SelectChunkFromAvailableOptions));

        foreach (var codeInstruction in instructions)
        {
            if (codeInstruction.LoadsField(targetField))
            {
                codeInstruction.opcode = OpCodes.Call;
                codeInstruction.operand = chunkSelector;
            }

            yield return codeInstruction;
        }
    }

    public static ThingDef SelectChunkFromAvailableOptions()
    {
        if (ShipChunkDrop_TranspilerMod.Instance.Settings.SmallChunksAlso)
        {
            return (from defs in DefDatabase<ThingDef>.AllDefs
                where defs.defName.StartsWith("ShipChunk") && !defs.defName.Contains("Incoming")
                select defs).RandomElement();
        }

        return (from defs in DefDatabase<ThingDef>.AllDefs
            where defs.defName.StartsWith("ShipChunk") && !defs.defName.Contains("Incoming") &&
                  !defs.defName.Contains("small")
            select defs).RandomElement();
    }
}