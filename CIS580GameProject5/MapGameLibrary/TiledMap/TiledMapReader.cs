using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using TRead = MapGameLibrary.TiledMap;

namespace MapGameLibrary
{
    public class TiledMapReader : ContentTypeReader<TRead>
    {
        protected override TRead Read(ContentReader input, TRead existingInstance)
        {
            // Read in the content properties in the exact same 
            // order they were written in the corresponding writer

            //var name = input.ReadString();

            // Read in the tile attributes
            var mapWidth = input.ReadInt32();
            var mapHeight = input.ReadInt32();
            var tileWidth = input.ReadInt32();
            var tileHeight = input.ReadInt32();
            var tileCount = input.ReadInt32();

            // Read in the tiles - the number will vary based on the tileset 
            var mapTiles = new MapTile[tileCount];
            for (int i = 0; i < tileCount; i++)
            {
                var x = input.ReadInt32()*tileWidth;
                var y = input.ReadInt32()*tileHeight;
                var id = input.ReadInt32();
                
                mapTiles[i] = new MapTile(id, tileWidth, tileHeight, x, y);
            }

            // Construct and return the tileset
            return new TiledMap(mapTiles,mapWidth,mapHeight, tileCount);
        }
    }
}
