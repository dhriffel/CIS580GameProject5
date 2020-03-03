using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.VisualBasic;

using TInput = MapGameContentExtension.TiledMapContent;

namespace MapGameContentExtension
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to import a file from disk into the specified type, TImport.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentImporter attribute to specify the correct file
    /// extension, display name, and default processor for this importer.
    /// </summary>

    [ContentImporter(".tmx", DisplayName = "TMX Importer - Tiled", DefaultProcessor = "TileMapProcessor - Tiled")]
    public class TileMapImporter : ContentImporter<TInput>
    {
        public override TInput Import(string filename, ContentImporterContext context)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filename);

            // The tileset should be the tileset tag
            XmlNode tileset = document.SelectSingleNode("//map");

            // The attributes on the tileset are the properties of our spritesheet
            //string name = tileset.Attributes["name"].Value;
            int mapWidth = int.Parse(tileset.Attributes["width"].Value);
            int mapHeight = int.Parse(tileset.Attributes["height"].Value);
            int tileWidth = int.Parse(tileset.Attributes["tilewidth"].Value);
            int tileHeight = int.Parse(tileset.Attributes["tileheight"].Value);

            tileset = document.SelectSingleNode("//tileset");
            int tileSetId = int.Parse(tileset.Attributes["firstgid"].Value);

            
            // A tileset will contain an image element that serves as the source of the tiles
            XmlNode mapData = tileset.SelectSingleNode("//data");
            var mapCSVString = mapData.InnerText;

            return new TiledMapContent()
            {
                //Name = name,
                MapWidth = mapWidth,
                MapHeight = mapHeight,
                TileWidth = tileWidth,
                TileHeight = tileHeight,
                TileCount = (mapWidth*mapHeight),
                TileSetId = tileSetId,
                MapCSV = mapCSVString
            };
        }

    }

}
