using Mlie;
using UnityEngine;
using Verse;

namespace ShipChunkDrop_Transpiler;

[StaticConstructorOnStartup]
internal class ShipChunkDrop_TranspilerMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static ShipChunkDrop_TranspilerMod instance;

    private static string currentVersion;

    /// <summary>
    ///     The private settings
    /// </summary>
    private ShipChunkDrop_TranspilerSettings settings;

    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public ShipChunkDrop_TranspilerMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.VariousSpaceShipChunk"));
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal ShipChunkDrop_TranspilerSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<ShipChunkDrop_TranspilerSettings>();
            }

            return settings;
        }
        set => settings = value;
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Various Space Ship Chunk";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.CheckboxLabeled("VSSC.SmallChunksAlso".Translate(), ref Settings.SmallChunksAlso,
            "VSSC.SmallChunksAlso.Tooltip".Translate());
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("VSSC.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
        Settings.Write();
    }
}