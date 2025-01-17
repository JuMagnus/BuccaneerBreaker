﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;



namespace BuccaneerBreaker
{
    public class SceneMenu : Scene
    {
        
        private IAssets _assets = ServicesLocator.Get<IAssets>();
        private IInputs _inputs = ServicesLocator.Get<IInputs>();
        private ISceneManager _sceneManager = ServicesLocator.Get<ISceneManager>();
        private IScreen _screen = ServicesLocator.Get<IScreen>();
        private Sprite _background;
        private Button _playButton;
        private Button _quit;
        private SoundEffect _clickButton;
        
        public override void Load()
        {
            
            _background = new Sprite(Vector2.Zero, _assets.Get<Texture2D>("TexTitle"));
            AddSprite(_background);


            _playButton = new Button(new Rectangle((int)_screen.Center.X-150, (int)_screen.Center.Y, 300,100), Color.White, _assets.Get<SpriteFont>("FontTradeWind"), "PLAY");
            AddSprite(_playButton);
            _quit = new Button(new Rectangle((int)_screen.Center.X - 150, (int)_screen.Center.Y + 150, 300, 100), Color.White, _assets.Get<SpriteFont>("FontTradeWind"), "QUIT");
            AddSprite(_quit);


            PlaySong("MusicTitle", true);

            _clickButton = _assets.Get<SoundEffect>("SoundClic");
            

            base.Load();
        }
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);

            if ( _inputs.IsMouseLeftClicked() )
            {
                Vector2 mousePosition = _inputs.GetMousePosition();

                if (_playButton.colliderBox.Contains(mousePosition.X, mousePosition.Y))
                {
                    _clickButton.Play();
                    _sceneManager.Load(typeof(SceneChoosePaddle));
                }
                else if (_quit.colliderBox.Contains(mousePosition.X, mousePosition.Y))
                {
                    _sceneManager.ExitGame();
                }
            }

           

        }


    }
}
