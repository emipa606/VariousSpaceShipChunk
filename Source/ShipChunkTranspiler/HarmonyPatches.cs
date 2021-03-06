﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ShipChunkDrop_Transpiler
{
    // Token: 0x02000002 RID: 2
    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        static HarmonyPatches()
        {
            new Harmony("mehni.rimworld.shipchunks.main").Patch(
                AccessTools.Method(typeof(IncidentWorker_ShipChunkDrop), "SpawnChunk"), null, null,
                new HarmonyMethod(typeof(HarmonyPatches), "IncidentWorker_ShipChunkDrop_SpawnChunk_Transpiler"));
        }

        // Token: 0x06000002 RID: 2 RVA: 0x0000208F File Offset: 0x0000028F
        public static IEnumerable<CodeInstruction> IncidentWorker_ShipChunkDrop_SpawnChunk_Transpiler(
            IEnumerable<CodeInstruction> instructions)
        {
            var chunkSelector = AccessTools.Method(typeof(HarmonyPatches), "SelectChunkFromAvailableOptions");
            var i = 0;
            foreach (var codeInstruction in instructions)
            {
                if (codeInstruction.opcode == OpCodes.Ldsfld)
                {
                    if (i == 1)
                    {
                        codeInstruction.opcode = OpCodes.Call;
                        codeInstruction.operand = chunkSelector;
                    }

                    var num = i;
                    i = num + 1;
                }

                yield return codeInstruction;
            }
        }

        // Token: 0x06000003 RID: 3 RVA: 0x0000209F File Offset: 0x0000029F
        public static ThingDef SelectChunkFromAvailableOptions()
        {
            if (LoadedModManager.GetMod<ShipChunkDrop_TranspilerMod>().GetSettings<ShipChunkDrop_TranspilerSettings>()
                .SmallChunksAlso)
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
}