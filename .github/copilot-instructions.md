# GitHub Copilot Instructions for Various Space Ship Chunk (Continued)

## Mod Overview and Purpose

The "Various Space Ship Chunk (Continued)" mod enhances the gameplay experience of RimWorld by introducing new types of ship chunks that can drop during ship chunk drop events. This mod is a continuation of the original mod by totobrother, updated to include a chunk that provides uranium, and an option to spawn smaller chunks. The mod is designed to be compatible with any other mods and can be added to any existing save file without issues, thanks to the robust code developed by Mehni.

## Key Features and Systems

- **New Ship Chunks**: Introduces various types of ship chunks, including those containing uranium.
- **Customizable Spawns**: Provides an option to spawn smaller chunks, adding variability to gameplay.
- **Compatibility**: Works seamlessly with any mod and can be integrated into existing save files.
- **Art and Design**: Features artwork by yionguon, adding a unique visual element to the game.

## Coding Patterns and Conventions

- **Consistent Naming**: Use PascalCase for class names and camelCase for method names and variables.
- **Structured Code**: Organize code into separate files for different functionalities (e.g., settings, transpilers).
- **Comments and Documentation**: Include clear comments and XML documentation for methods and classes to enhance readability and maintainability.

## XML Integration

The mod uses XML files to define new thing definitions and other game data:

- **Thing Definitions**: Located in `DefInjected/ThingDef/Buildings_Exotic.xml`, define the properties of the new ship chunks.
- **Translation Templates**: Located in `TranslationTemplate/ThingDef/Buildings_Exotic.xml`, support for localization and mod translation.

## Harmony Patching

Harmony is used to alter existing game behavior without changing the core game files:

- **Transpiler Patches**: Implemented in `ShipChunkDrop_TranspilerMod.cs` and `HarmonyPatches.cs` to selectively modify the game logic involved in ship chunk drops.
- **Custom Methods**: Specific methods like `IncidentWorker_ShipChunkDrop_SpawnChunk_Transpiler` are used to customize the chunk spawning logic.

## Suggestions for Copilot

1. **Code Completion**: Write method implementations by suggesting structured code blocks based on the surrounding code context.
2. **XML Suggestions**: Provide suggestions for XML element completions to maintain consistent data definitions.
3. **Harmony Patch Assistance**: Assist in creating well-formed transpiler methods or prefix/postfix patches.
4. **Debugging Support**: Suggest common troubleshooting steps based on known issues in mod development.
5. **Automated Testing**: Propose simple testing cases to ensure mod features work as expected following implementation changes.

By adhering to these guidelines and leveraging GitHub Copilot, developers can maintain high-quality code and reliable mod functionality.

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

