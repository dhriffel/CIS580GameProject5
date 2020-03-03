using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGameLibrary
{
    public class MapTile
    {

        private int tileWidth;
        private int tileHeight;
        private int id;
        public Rectangle bounds;

        public MapTile(int id, int tileWidth, int tileHeight, int x, int y)
        {
            this.id = id;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            bounds = new Rectangle(x,y,tileWidth,tileHeight);

        }

        public void ScaleTile(int scale)
        {
            
            bounds.Height *= scale;
            bounds.Width *= scale;
            bounds.X *= scale;
            bounds.Y *= scale;

        }

        public void Draw(SpriteBatch SpriteBatch, Tileset sprites, Color color)
        {
            sprites[id].Draw(SpriteBatch, bounds, color);
        }
        public void Draw(SpriteBatch SpriteBatch, Tileset sprites, float scale ,Color color)
        {
            sprites[id].Draw(SpriteBatch, new Vector2(bounds.X, bounds.Y), Color.White, 0, new Vector2(bounds.X, bounds.Y), scale, SpriteEffects.None, 1);
        }
    }
}
