using UnityEngine;
using Verse;

namespace ShipChunkDrop_Transpiler
{
    [StaticConstructorOnStartup]
    internal class ShipChunkDrop_TranspilerMod : Mod
    {
        /// <summary>
        /// Cunstructor
        /// </summary>
        /// <param name="content"></param>
        public ShipChunkDrop_TranspilerMod(ModContentPack content) : base(content)
        {
            instance = this;
        }

        /// <summary>
        /// The instance-settings for the mod
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
            set
            {
                settings = value;
            }
        }

        /// <summary>
        /// The title for the mod-settings
        /// </summary>
        /// <returns></returns>
        public override string SettingsCategory()
        {
            return "Various Space Ship Chunk";
        }

        /// <summary>
        /// The settings-window
        /// For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
        /// </summary>
        /// <param name="rect"></param>
        public override void DoSettingsWindowContents(Rect rect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.CheckboxLabeled("Also use small chunks in event", ref Settings.SmallChunksAlso, "Adds a smaller chunk as possible debris");
            listing_Standard.End();
            Settings.Write();
        }

        /// <summary>
        /// The instance of the settings to be read by the mod
        /// </summary>
        public static ShipChunkDrop_TranspilerMod instance;

        /// <summary>
        /// The private settings
        /// </summary>
        private ShipChunkDrop_TranspilerSettings settings;

    }
}
