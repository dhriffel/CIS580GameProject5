using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGameLibrary
{
    public class TiledMap
    {
        int mapHeight;
        int mapWidth;
        int tileCount;

        MapTile[] mapTiles;

        public TiledMap(MapTile[] mapTiles, int mapWidth, int mapHeight, int tileCount)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.mapTiles = mapTiles;
            this.tileCount = tileCount;
        }

        /// <summary>
        /// An indexer for accessing individual tiles in the map
        /// </summary>
        /// <param name="index">The index of the tile</param>
        /// <returns>The sprite</returns>
        public MapTile this[int index]
        {
            get => mapTiles[index];
        }

        /// <summary>
        /// The number of tiles in the set
        /// </summary>
        public int Count => mapTiles.Length;
    }
}
