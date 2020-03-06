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

        protected int tileWidth;
        protected int tileHeight;
        public int id;
        public Rectangle bounds;
        protected bool changeable;

        public MapTile(int id, int tileWidth, int tileHeight, int x, int y)
        {
            this.id = id;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            bounds = new Rectangle(x, y, tileWidth, tileHeight);
            changeable = true;
        }

        public void ScaleTile(int scale)
        {

            bounds.Height *= scale;
            bounds.Width *= scale;
            bounds.X *= scale;
            bounds.Y *= scale;

        }
        public void Update(Matrix transform)
        {
            Vector2 vect = new Vector2(bounds.X, bounds.Y);
            vect = Vector2.Transform(vect, transform);
            this.bounds.X = (int)vect.X;
            this.bounds.Y = (int)vect.Y;
        }

        public int GetId() {return id; }

        public virtual void ChangeTile(int id) { this.id = id; }

        public void Draw(SpriteBatch SpriteBatch, Tileset sprites, Color color)
        {
            sprites[id].Draw(SpriteBatch, bounds, color, 0,Vector2.Zero,SpriteEffects.None,0.5f);
        }
        public void Draw(SpriteBatch SpriteBatch, Tileset sprites, float scale ,Color color)
        {
            sprites[id].Draw(SpriteBatch, new Vector2(bounds.X, bounds.Y), Color.White, 0, new Vector2(bounds.X, bounds.Y), scale, SpriteEffects.None, .5f);
        }
    }
}
