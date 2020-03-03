using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using TWrite = MapGameContentExtension.TiledMapContent;

namespace PlatformerContentExtension
{
    /// <summary>
    /// A ContentTypeWriter for the TiledSpriteSheetContent type
    /// </summary>
    [ContentTypeWriter]
    public class TiledMapWriter : ContentTypeWriter<TWrite>
    {

        /// <summary>
        /// Write the binary (xnb) file corresponding to the supplied 
        /// TilesetContent that will be imported into our game
        /// as a TiledMap
        /// </summary>
        /// <param name="output">The ContentWriter that writes the binary output</param>
        /// <param name="value">The TiledMapContent we are writing</param>
        protected override void Write(ContentWriter output, TWrite value)
        {

            //output.Write(value.Name);

            // Write the map/tile width & height 
            output.Write(value.MapWidth);
            output.Write(value.MapHeight);
            output.Write(value.TileWidth);
            output.Write(value.TileHeight);
            
            // Write the number of map tiles - this will be used to 
            // specify the expected number of map tiles in the reader
            output.Write(value.TileCount);

            // Write the individual tile data
            for (int i = 0; i < value.TileCount; i++)
            {
                var tile = value.MapTiles[i];
                // Writing the map tile Id
                output.Write(tile.X);
                output.Write(tile.Y);
                output.Write(tile.Id);
            }

        }

        /// <summary>
        /// Gets the reader needed to read the binary content written by this writer
        /// </summary>
        /// <param name="targetPlatform"></param>
        /// <returns></returns>
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "MapGameLibrary.TiledMapReader, MapGameLibrary";
        }
    }
}
