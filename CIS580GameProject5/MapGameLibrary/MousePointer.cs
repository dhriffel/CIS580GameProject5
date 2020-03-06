using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGameLibrary
{
    public class MousePointer
    {
        Texture2D pixel;

        int X;
        int Y;

        MapTile mousedTile;
        bool mouseOverTile;

        int selectedTileId = -1;
        TimeSpan timer;

        private bool HandleClick(TiledMap map)
        {
            if (mouseOverTile &&  timer.TotalMilliseconds > 10)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (mousedTile.id == 0)
                    {
                        mousedTile.ChangeTile(17);
                        return map.isPath();
                    }
                }
                else if(Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    if (mousedTile.id == 17)
                    {
                        mousedTile.ChangeTile(0);
                    }
                }
                
                timer = new TimeSpan(0);
            }
            return false;
        }

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            pixel = new Texture2D(graphicsDevice, 1, 1);
            Color[] colors = new Color[1];
            colors[0] = Color.Red;
            pixel.SetData<Color>(colors);
            timer = new TimeSpan(0);
        }

        public bool Update(TiledMap map)
        {
            X = Mouse.GetState().X;
            Y = Mouse.GetState().Y;
            //Debug.WriteLine(X + ":" + Y);
            timer += TimeSpan.FromMilliseconds(1);
            for (int i = 0; i < map.Count; i++)
            {
                if (Collisions.pointInRectangle(X, Y, map[i].bounds.X, map[i].bounds.X + map[i].bounds.Width, map[i].bounds.Y, map[i].bounds.Y + map[i].bounds.Height))
                {
                    mousedTile = map[i];
                    mouseOverTile = true;
                    //Debug.WriteLine("OverTile");
                    break;
                }
                else
                {
                    mousedTile = null;
                    mouseOverTile = false;
                }
            }
            
            return HandleClick(map);

        }

        public void Draw(SpriteBatch spriteBatch,Tileset tileset)
        {

            if (selectedTileId != -1)
            {
                
            }
            if (mouseOverTile)
            {
                spriteBatch.Draw(pixel, destinationRectangle:mousedTile.bounds, color:Color.Red, layerDepth: 1.0f);

            }
        }
    }
}
