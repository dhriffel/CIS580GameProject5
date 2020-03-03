using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MapGameContentExtension
{
    /// <summary>
    /// A class representing the details of a single 
    /// map tile in a Tiled map file
    /// </summary>
    public class MapTileContent
    {

        public int X { get; set; }
        public int Y { get; set; }
        /// <summary>
        /// The MapTile's Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Creates a new TileContent with the specified source rectangle
        /// </summary>
        /// <param name="source">The source rectangle of the tile in its spritesheet</param>
        public MapTileContent(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}
