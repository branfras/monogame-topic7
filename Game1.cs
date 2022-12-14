using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_topic7
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D pacRight;
        Texture2D pacLeft;
        Texture2D pacUp;
        Texture2D pacDown;
        Texture2D pacSleep;
        Texture2D pacTexture;

        Rectangle pacLocation;
        KeyboardState keyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pacLocation = new Rectangle(10, 10, 75, 75);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pacUp = Content.Load<Texture2D>("PacUp");
            pacDown = Content.Load<Texture2D>("PacDown");
            pacLeft = Content.Load<Texture2D>("PacLeft");
            pacRight = Content.Load<Texture2D>("PacRight");
            pacSleep = Content.Load<Texture2D>("PacSleep");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacLocation.Y -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacLocation.Y += 2;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacLocation.X -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacLocation.X += 2;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacTexture = pacUp;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacTexture = pacDown;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacTexture = pacLeft;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacTexture = pacRight;
            }
            else
            {
                pacTexture = pacSleep;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}