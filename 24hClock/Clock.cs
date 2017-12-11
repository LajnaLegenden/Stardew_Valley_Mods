using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace Lajna.Mods.MilitaryTime
{
    /// <summary>An overlay menu which replaces the game's default clock.</summary>
    internal class Clock : IClickableMenu
    {
        /*********
        ** Properties
        *********/
        /// <summary>The source rectangle of the clock background in the spritesheet.</summary>
        private readonly Rectangle SourceRect = new Rectangle(360, 460, 40, 9);


        /*********
        ** Public methods
        *********/
        /// <summary>The method invoked when the player right-clicks on the lookup UI.</summary>
        /// <param name="x">The X-position of the cursor.</param>
        /// <param name="y">The Y-position of the cursor.</param>
        /// <param name="playSound">Whether to enable sound.</param>
        public override void receiveRightClick(int x, int y, bool playSound = true) { }

        /// <summary>Render the UI.</summary>
        /// <param name="spriteBatch">The sprite batch being drawn.</param>
        public override void draw(SpriteBatch spriteBatch)
        {
            // format time
            string time = "";
            if (Game1.timeOfDay < 1000)
                time = "0" + Game1.timeOfDay;

            string hr = time.Substring(0, 2);
            string min = time.Substring(2, 2);

            time = hr + ":" + min;

            // get positions
            DayTimeMoneyBox box = Game1.onScreenMenus.OfType<DayTimeMoneyBox>().First();
            Vector2 textPosition = box.position + new Vector2(-20, -9);
            Vector2 backgroundPosition = box.position + new Vector2(108, 115);
            Vector2 textSize = Game1.dialogueFont.MeasureString(Game1.timeOfDay.ToString());
            Vector2 textOffset = new Vector2((float)(this.SourceRect.X * 0.55 - textSize.X / 2.0), (float)(this.SourceRect.Y * .31 - textSize.Y / 2.0));

            // draw clock
            spriteBatch.Draw(Game1.mouseCursors, backgroundPosition, this.SourceRect, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(Game1.dialogueFont, time, textPosition + textOffset, Color.Black);
        }
    }
}