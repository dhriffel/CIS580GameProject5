﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MapGameLibrary;
using System.Diagnostics;

namespace CIS580GameProject5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Tileset tileset;
        TiledMap[] maps;
        TiledMap currentMap;
        int mapIndex = 0;
        MousePointer mousePoint;

        private int screenWidth = 1500;
        private int screenHeight = 1000;

        int scale = 3;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            mousePoint = new MousePointer();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            IsMouseVisible = true;
            mousePoint.Initialize(GraphicsDevice);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tileset = Content.Load<Tileset>("Terrain clone");
            var map1 = Content.Load<TiledMap>("gameMap1");
            var map2 = Content.Load<TiledMap>("gameMap2");
            var map3 = Content.Load<TiledMap>("gameMap3");

            maps = new TiledMap[] { map1, map2, map3 };

            for (int i = 0; i < maps.Length; i++)
            {
                for (int j = 0; j < maps[i].Count; j++)
                    maps[i][j].ScaleTile(scale);
            }

            currentMap = maps[mapIndex];

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (mousePoint.Update(currentMap))
            {
                if(mapIndex+1 < maps.Length)
                {
                    mapIndex++;
                    currentMap = maps[mapIndex];
                }
                else
                    Exit();
            }

            // TODO: Add your update logic here

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            mousePoint.Draw(spriteBatch, tileset);

            for (int i = 0; i < currentMap.Count; i++)
            {
                currentMap[i].Draw(spriteBatch,tileset,Color.White);
            }
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
