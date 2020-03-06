using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace MapGameContentExtension
{
    /// <summary>
    /// A class representing the content associated with a Tiled tileset.
    /// It is used as an intermediary stage in the content pipeline
    /// </summary>
    public class TiledMapContent
    {
        public string Name { get; set; }

        public int MapWidth { get; set; }

        public int MapHeight { get; set; }

        public int TileWidth { get; set; }

        public int TileHeight { get; set; }

        public int TileCount { get; set; }

        public int TileSetId { get; set; }

        public string MapCSV { get; set; }

        public MapTileContent[] MapTiles;

    }
}
