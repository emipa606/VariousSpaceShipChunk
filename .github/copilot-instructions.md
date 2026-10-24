# GitHub Copilot Instructions for Various Space Ship Chunk (Continued) Mod

## Mod Overview and Purpose
The Various Space Ship Chunk (Continued) mod is an update to the original Various Space Ship Chunk mod. It adds new ship chunks to the game, including a chunk that provides uranium. Users have the option to spawn smaller chunks as well. The mod aims to enhance the loot system by adding diverse ship chunks that can drop during gameplay. It is compatible with any mod and can be integrated into any save file.

## Key Features and Systems
- **Uranium Chunk**: A new chunk that provides uranium, adding a valuable resource to the game.
- **Smaller Chunk Option**: Allows players to spawn smaller chunks, increasing the variety of loot.
- **Compatibility**: Works with any mod, ensuring broad applicability.
- **Loot System Enhancement**: Introduces new ship chunks that can drop during gameplay, enriching the experience.

## Coding Patterns and Conventions
- **C# Files**: The mod is written in C# and follows common RimWorld modding conventions.
  - **HarmonyPatches.cs**: Contains harmony patches for modifying the game's behavior.
  - **ShipChunkDrop_TranspilerMod.cs**: Manages the mod's settings and configuration.
  - **ShipChunkDrop_TranspilerSettings.cs**: Handles the mod's settings, including saving and loading data.
- **XML Files**: XML files are used to define game objects and their properties.
  - **Buildings_Exotic.xml**: Defines the new ship chunks.

## XML Integration
The XML integration is crucial for defining the new ship chunks. The `Buildings_Exotic.xml` file contains the definitions for these chunks, including their properties and resources.

xml
<ThingDef ParentName="Base_ShipChunk" Name="VariousSpaceShipChunk_UraniumChunk" defName="VariousSpaceShipChunk_UraniumChunk">
    <label>Uranium Chunk</label>
    <description>A chunk of uranium found in the wreckage of an alien ship.</description>
    <defStuffCategories>
        <li>Mineral</li>
    </defStuffCategories>
    <thingCategories>
        <li>Building</li>
    </thingCategories>
    <marketValue>500</marketValue>
    <stackLimit>100</stackLimit>
    <graphicData>
        <texPath>VariousSpaceShipChunk/UraniumChunk</texPath>
        <drawSize>2</drawSize>
    </graphicData>
</ThingDef>


## Harmony Patching
Harmony patching is used to modify the game's behavior without altering the original source code. The `HarmonyPatches.cs` file contains the patches for adding the new ship chunks to the game.

csharp
[HarmonyPatch(typeof(IncidentWorker_ShipChunkDrop))]
[HarmonyPatch("SpawnChunk")]
public static class IncidentWorker_ShipChunkDrop_SpawnChunk_Patch
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = instructions.ToList();
        var index = codes.FindIndex(code => code.opcode == OpCodes.Ldc_I4_1);
        if (index != -1)
        {
            codes[index].operand = 2; // Change the value to 2 to spawn smaller chunks
        }
        return codes;
    }
}


## Suggestions for Copilot
- **XML Definitions**: When generating XML files, ensure they are structured correctly and follow RimWorld's XML conventions.
- **Harmony Patches**: When creating harmony patches, be cautious with modifying existing code and ensure that the patches do not break the game.
- **Settings Management**: When managing settings, ensure that data is correctly exposed and saved, and that the settings interface is user-friendly.
- **Compatibility**: When adding new features, ensure that the mod remains compatible with other mods and that there are no conflicts.

By following these guidelines, you can effectively use GitHub Copilot to enhance your modding experience and create high-quality RimWorld mods.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

