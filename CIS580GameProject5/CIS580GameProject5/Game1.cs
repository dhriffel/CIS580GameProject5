using Microsoft.Xna.Framework;
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
        TiledMap map;

        int scale = 4;

        Texture2D pixel;
        bool mouseOverTile;
        MapTile mousedTile;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            Color[] colors = new Color[1];
            colors[0] = Color.White;
            pixel.SetData <Color>(colors);

            mouseOverTile = false;

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
            tileset = Content.Load<Tileset>("New Piskel");
            map = Content.Load<TiledMap>("gameMap");

            for (int i = 0; i < map.Count; i++)
            {
                map[i].ScaleTile(scale);
            }

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

            var mouseX = Mouse.GetState().X;
            var mouseY = Mouse.GetState().Y;

            Debug.WriteLine(mouseX + ":" + mouseY);
            for (int i = 0; i < map.Count; i++)
            {
                if (Collisions.pointInRectangle(mouseX, mouseY, map[i].bounds.X, map[i].bounds.X + map[i].bounds.Width, map[i].bounds.Y, map[i].bounds.Y + map[i].bounds.Height))
                {
                    mousedTile = map[i];
                    mouseOverTile = true;
                    break;
                }
                else
                {
                    mousedTile = null;
                    mouseOverTile = false;
                }
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
            if (mouseOverTile)
            {
                spriteBatch.Draw(pixel, mousedTile.bounds, Color.Red);
                Debug.WriteLine("OverTile");
            }
            else
            for (int i = 0; i < map.Count; i++)
            {
                map[i].Draw(spriteBatch,tileset,Color.White);
            }
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
