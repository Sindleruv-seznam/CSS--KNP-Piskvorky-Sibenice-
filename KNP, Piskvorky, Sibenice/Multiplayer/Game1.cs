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
        private Vector2 _pos = new(100, 100);

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
            if (k.IsKeyDown(Keys.W)) _pos.Y -= 3;
            if (k.IsKeyDown(Keys.S)) _pos.Y += 3;
            if (k.IsKeyDown(Keys.A)) _pos.X -= 3;
            if (k.IsKeyDown(Keys.D)) _pos.X += 3;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_pixel, new Rectangle((int)_pos.X, (int)_pos.Y, 50, 50), Color.Red);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
