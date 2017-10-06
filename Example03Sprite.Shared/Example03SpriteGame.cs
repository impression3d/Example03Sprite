using Impression;
using Impression.Graphics;
using Impression.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Example03Sprite
{
    public class Example03SpriteGame : Impression.Game
    {
		GraphicsDeviceManager graphics;

		SpriteBatch spriteBatch;
		List<Sprite> sprites;
		int currentSpriteIndex = 0;

		MouseState currentMouseState;
		MouseState lastMouseState;

        public Example03SpriteGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						this.IsMouseVisible = true;
					}
					break;
                case PlatformType.WindowsStore:
                case PlatformType.WindowsMobile:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
				case PlatformType.Android:
				case PlatformType.iOS:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
			}

            this.View.Title = "Example03Sprite";
        }

        protected override void Initialize()
        { 
            base.Initialize();

            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            sprites = new List<Sprite>();

            // Load all sprites
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/arm_hand@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/arm_lower@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/arm_upper@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/head@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/leg_foot@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/leg_lower@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/leg_upper@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/lowerbody@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Robot/upperbody@Robot"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/head@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/innerarm_hand@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/innerarm_lower@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/innerarm_upper@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/innerleg_foot@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/innerleg_lower@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/innerleg_upper@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/innerweapon@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/lowerbody@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/outerarm_hand@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/outerarm_lower@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/outerarm_upper@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/outerleg_foot@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/outerleg_lower@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/outerleg_upper@Warrior"));
            sprites.Add(this.Content.Load<Sprite>("Atlases/Warrior/upperbody@Warrior"));
        }

        protected override void UnloadContent()
        {
            // do something

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						if (Keyboard.GetState().IsKeyDown(Keys.Escape))
							this.Exit();
					}
					break;
				default:
					{
						// do nothings
					}
					break;
			}

			lastMouseState = currentMouseState;
			currentMouseState = Mouse.GetState();

			// Allows sprites to sequenced when left button was just pressed
			if (lastMouseState.LeftButton == ButtonState.Released && 
			    currentMouseState.LeftButton == ButtonState.Pressed)
			{
				currentSpriteIndex++;

				// When current sprite index is out of range, reset index to zero
				if (!(currentSpriteIndex < sprites.Count))
				{
					currentSpriteIndex = 0;
				}
			}
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			graphics.GraphicsDevice.Clear(Color.BurlyWood);

			spriteBatch.Begin();

			// Draw sprite on center of screen
			spriteBatch.Draw(
				sprites[currentSpriteIndex],
				new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2),
				null,
				Color.White,
				0,
				new Vector2(sprites[currentSpriteIndex].Width / 2, sprites[currentSpriteIndex].Height / 2),
				1,
				SpriteEffects.None,
				0);

			spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}