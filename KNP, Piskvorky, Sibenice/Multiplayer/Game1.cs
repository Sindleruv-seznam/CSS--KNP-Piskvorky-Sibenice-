using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Multiplayer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _pixel;

        // Red square controlled by WASD
        private Vector2 _posWASD = new(100, 100);
        // Green square controlled by IJKL
        private Vector2 _posIJKL = new(200, 100);
        // Blue square controlled by Arrow keys
        private Vector2 _posArrows = new(300, 100);

        private const int SquareSize = 50;
        private const float Speed = 3f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var k = Keyboard.GetState();

            // WASD control the red square
            if (k.IsKeyDown(Keys.W)) _posWASD.Y -= Speed;
            if (k.IsKeyDown(Keys.S)) _posWASD.Y += Speed;
            if (k.IsKeyDown(Keys.A)) _posWASD.X -= Speed;
            if (k.IsKeyDown(Keys.D)) _posWASD.X += Speed;

            // IJKL control the green square
            if (k.IsKeyDown(Keys.I)) _posIJKL.Y -= Speed;
            if (k.IsKeyDown(Keys.K)) _posIJKL.Y += Speed;
            if (k.IsKeyDown(Keys.J)) _posIJKL.X -= Speed;
            if (k.IsKeyDown(Keys.L)) _posIJKL.X += Speed;

            // Arrow keys control the blue square
            if (k.IsKeyDown(Keys.Up)) _posArrows.Y -= Speed;
            if (k.IsKeyDown(Keys.Down)) _posArrows.Y += Speed;
            if (k.IsKeyDown(Keys.Left)) _posArrows.X -= Speed;
            if (k.IsKeyDown(Keys.Right)) _posArrows.X += Speed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            // Red: WASD
            _spriteBatch.Draw(_pixel, new Rectangle((int)_posWASD.X, (int)_posWASD.Y, SquareSize, SquareSize), Color.Red);
            // Green: IJKL
            _spriteBatch.Draw(_pixel, new Rectangle((int)_posIJKL.X, (int)_posIJKL.Y, SquareSize, SquareSize), Color.Green);
            // Blue: Arrow keys
            _spriteBatch.Draw(_pixel, new Rectangle((int)_posArrows.X, (int)_posArrows.Y, SquareSize, SquareSize), Color.Blue);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
