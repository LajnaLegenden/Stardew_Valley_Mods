using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace Lajna.Mods.MilitaryTime
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            TimeEvents.AfterDayStarted += TimeEvents_AfterDayStarted;
        }
        private void TimeEvents_AfterDayStarted(object sender, EventArgs e)
        {
            Game1.onScreenMenus.Add(new Clock());
        }
    }
}
