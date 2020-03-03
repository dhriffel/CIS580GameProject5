﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using TRead = MapGameLibrary.Tileset;

namespace MapGameLibrary
{
    public class TilesetReader : ContentTypeReader<TRead>
    {
        protected override TRead Read(ContentReader input, TRead existingInstance)
        {
            // Read in the content properties in the exact same 
            // order they were written in the corresponding writer
            // Read in the texture 
            var texture = input.ReadObject<Texture2D>();

            // Read in the tile attributes
            var tileWidth = input.ReadInt32();
            var tileHeight = input.ReadInt32();
            var tileCount = input.ReadInt32();

            // Read in the tiles - the number will vary based on the tileset 
            var tiles = new Tile[tileCount];
            for (int i = 0; i < tileCount; i++)
            {
                var source = new Rectangle(
                    input.ReadInt32(),
                    input.ReadInt32(),
                    tileWidth,
                    tileHeight);
                tiles[i] = new Tile(source, texture);
            }

            // Construct and return the tileset
            return new Tileset(tiles);
        }
    }
}
