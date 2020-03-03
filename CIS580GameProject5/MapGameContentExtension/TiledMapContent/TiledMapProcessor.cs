using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

using TInput = MapGameContentExtension.TiledMapContent;
using TOutput = MapGameContentExtension.TiledMapContent;

namespace MapGameContentExtension
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to apply custom processing to tileset data 
    /// </summary>
    [ContentProcessor(DisplayName = "TiledMap Processor - Tiled")]
    public class TiledMapProcessor : ContentProcessor<TInput, TOutput>
    {
        /// <summary>
        /// Processes the raw .tmx XML and creates a TiledMapContent
        /// for use in an XNA framework game
        /// </summary>
        /// <param name="input">The XML string</param>
        /// <param name="context">The pipeline context</param>
        /// <returns>A TiledMapContent instance corresponding to the tmx input</returns>
        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            // Create the Tiles array
            input.MapTiles = new MapTileContent[input.TileCount];
            var columns = input.MapWidth;
            var ID = input.MapCSV.Split(',');
            // Run the logic to generate the individual tile source rectangles
            for (int i = 0; i < input.TileCount; i++)
            {
                input.MapTiles[i] = new MapTileContent(Int32.Parse(ID[i])-1, i%columns, i/columns);
            }

            // The tileset has been processed
            return input;
        }
    }
}