using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGameLibrary
{
    public class TiledMap
    {
        public int mapHeight;
        public int mapWidth;
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

        public bool isPath()
        {
            int currentIndex = 0;
            for(int t = 0; t < mapTiles.Length; t++)
            {
                if (this[t].id == 16)
                {
                    currentIndex = t;
                    break;
                }
            }

            if (currentIndex == 0)
                return false;

            return isPathHelper(currentIndex, currentIndex);
        }

        public bool isPathHelper(int currentIndex, int lastIndex)
        {
            if (this[currentIndex] == null)
                return false;

            if (this[currentIndex].id == 16 && currentIndex != lastIndex)
                return true;

            var right = currentIndex + 1;
            var down = currentIndex + mapWidth;
            var left = currentIndex - 1;
            var up = currentIndex - mapWidth;

            if((this[right].id == 17 || this[right].id == 16) && right != lastIndex)
                return isPathHelper(currentIndex + 1, currentIndex);
            if ((this[down].id == 17 || this[down].id == 16) && down != lastIndex)
                return isPathHelper(currentIndex + mapWidth, currentIndex);
            if ((this[left].id == 17 || this[left].id == 16) && left != lastIndex)
                return isPathHelper(currentIndex - 1, currentIndex);
            if ((this[up].id == 17 || this[up].id == 16) && up != lastIndex)
                return isPathHelper(currentIndex - mapWidth, currentIndex);

            

            return false;

        }
    }
}
