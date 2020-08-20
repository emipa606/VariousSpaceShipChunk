using Verse;

namespace ShipChunkDrop_Transpiler
{
    /// <summary>
    /// Definition of the settings for the mod
    /// </summary>
    internal class ShipChunkDrop_TranspilerSettings : ModSettings
    {
        public bool SmallChunksAlso = false;

        /// <summary>
        /// Saving and loading the values
        /// </summary>
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref SmallChunksAlso, "SmallChunksAlso", false, false);
        }
    }
}