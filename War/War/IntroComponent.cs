using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace War
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class IntroComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Texture2D warMap;
        Texture2D warLogo;
        Vector2 warLogoPosition;
        SpriteBatch mapBatch;
        SpriteBatch logoBatch;
        SpriteFont font;
        List<Button> buttons;
        public IntroComponent(Game game)
            : base(game)
        {    
            buttons = new List<Button>();
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            warLogoPosition = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 -400, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/10 -250);
            buttons.Add(new Button(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 100 ,GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/10 + 200));
            buttons.Add(new Button(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 100, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 10 + 300));
            buttons.Add(new Button(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 100, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 10 + 400));
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            
            try
            {
                
                MouseState mouse = Mouse.GetState();
                for (int i = 0; i < buttons.Count(); i++)
                {
                    buttons[i].changeCurrentFrame(mouse.X, mouse.Y);
                }
                if(mouse.LeftButton == ButtonState.Pressed)
                {
                    if (buttons[2].isCollided(mouse.X,mouse.Y))
                    {        
                        War.CurrentState = War.GameState.Credits;                 
                    }
                    if (buttons[1].isCollided(mouse.X, mouse.Y))
                    {
                        War.CurrentState = War.GameState.Instructions;
                    }
                }
            }
            catch (Exception e)
            {
            }



            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            mapBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            logoBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            
            float scale = calculateScale16x9();
            mapBatch.Draw(warMap, Vector2.Zero, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);           
            logoBatch.Draw(warLogo,warLogoPosition, null, Color.White, 0, Vector2.Zero, scale+0.5f, SpriteEffects.None, 0);
            for (int i = 0; i < buttons.Count; i++)
            {
                logoBatch.Draw(buttons[i].getButtonTexture(), buttons[i].getButtonPosition(),buttons[i].getCurrentFrame(), Color.White,0,Vector2.Zero,1,SpriteEffects.None,0);
            }
            
          //  batch.DrawString(font, "ALIEN RAID", new Vector2(150, 120), Color.Yellow);
          //  batch.DrawString(_smallFont, "Press ENTER to play", new Vector2(280, 250), Color.Cyan);
            mapBatch.End();
            logoBatch.End();

            base.Draw(gameTime);
        }
        protected override void LoadContent()
        {         
            mapBatch = new SpriteBatch(Game.GraphicsDevice);
            logoBatch = new SpriteBatch(Game.GraphicsDevice);
            warMap = Game.Content.Load<Texture2D>("WarMap16x9Grey");
            warLogo = Game.Content.Load<Texture2D>("WarLogo");          
            buttons[0].setButtonTexture(Game.Content.Load<Texture2D>("startButton"));
            buttons[1].setButtonTexture(Game.Content.Load<Texture2D>("instructionsButton"));
            buttons[2].setButtonTexture(Game.Content.Load<Texture2D>("creditsButton"));
          //  font = Game.Content.Load<SpriteFont>("Font/stats");
            base.LoadContent();
        }
        protected float calculateScale16x9()
        {
            float scale = 1.0f;
            float x = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            scale = x / 3360;
            return scale;
        }
    }
}
