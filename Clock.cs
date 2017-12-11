using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace Lajna.Mods.MilitaryTime
{
    internal class Clock : IClickableMenu
    {
        private Vector2 position;
        private Vector2 position2;
        private Rectangle sourceRect;

        int width1 = Game1.viewport.Width;
        int height1 = Game1.viewport.Height;

        public override void receiveRightClick(int x, int y, bool playSound = true) { }


        public override void draw(SpriteBatch b)
        {
            string asd = "";

            if (Game1.timeOfDay < 1000)
            {
                asd = "0" + Game1.timeOfDay.ToString();
            }

            string hr = asd.Substring(0, 2);
            string min = asd.Substring(2, 2);

            string time = hr + ":" + min;




            b.Draw(Game1.mouseCursors, this.position2, new Rectangle?(this.sourceRect), Color.White, 0f, Vector2.Zero, (float)4f, SpriteEffects.None, 0.9f);

            DayTimeMoneyBox box = Game1.onScreenMenus.OfType<DayTimeMoneyBox>().First();
            this.position = box.position + new Vector2(-20, -9); // change 100, 100 as needed to overlay the clock
            this.position2 = box.position + new Vector2(108, 115); // change 100, 100 as needed to overlay the clock
            this.sourceRect = new Rectangle(360, 460, 40, 9);

            Vector2 vector2_3 = Game1.dialogueFont.MeasureString(Game1.timeOfDay.ToString());
            Vector2 vector2_4 = new Vector2((float)((double)this.sourceRect.X * 0.55 - (double)vector2_3.X / 2.0), (float)((double)this.sourceRect.Y * .31 - (double)vector2_3.Y / 2.0));
            b.DrawString(Game1.dialogueFont, time.ToString(), this.position + vector2_4, Color.Black);
        }
    }
}