﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace BuccaneerBreaker
{
    public class SceneGameOver : Scene
    {
        private IAssets _assets = ServicesLocator.Get<IAssets>();
        private IInputs _inputs = ServicesLocator.Get<IInputs>();
        private ISceneManager _sceneManager = ServicesLocator.Get<ISceneManager>();
        private IScreen _screen = ServicesLocator.Get<IScreen>();

        private Sprite _background;
        private Button _playAgain;
        private Button _changePaddle;
        private Button _quit;

        private SoundEffect _clickButton;

        //J'aurais aimé regrouper les créations de boutons au sein d'une même boucle for mais les différences entre eux m'ont gêné.
        //Peut être en faisant autant de listes et en parcourant plusieurs listes en même temps, comme pour l'attaque spéciale du gunner.
        public override void Load()
        {
            _background = new Sprite(Vector2.Zero, _assets.Get<Texture2D>("TexGameOver"));
            AddSprite(_background);
            
            _playAgain = new Button(new Rectangle((int)_screen.Center.X - 275, (int)_screen.Center.Y, 550, 100), Color.White, _assets.Get<SpriteFont>("FontTradeWind"), "PLAY AGAIN");
            AddSprite(_playAgain);

            _changePaddle = new Button(new Rectangle((int)_screen.Center.X - 275, (int)_screen.Center.Y + 200, 550, 100), Color.White, _assets.Get<SpriteFont>("FontTradeWind"), "CHANGE CHARACTER");
            AddSprite(_changePaddle);

            _quit = new Button(new Rectangle((int)_screen.Center.X - 275, (int)_screen.Center.Y + 400, 550, 100), Color.White, _assets.Get<SpriteFont>("FontTradeWind"), "QUIT");
            AddSprite(_quit);

            _clickButton = _assets.Get<SoundEffect>("SoundClic");
            PlaySong("MusicLoose", false);

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            //Si j'arrive à mettre la création des boutons dans une boucle (et donc dans une liste), je pourrais simplifier également cette partie, comme dans la scène LevelSelection
            if (_inputs.IsMouseLeftClicked())
            {
                Vector2 mousePosition = _inputs.GetMousePosition();
                _clickButton.Play();
                if (_playAgain.colliderBox.Contains(mousePosition.X, mousePosition.Y))
                {
                    _sceneManager.Load(typeof(SceneGame));
                }
                else if (_changePaddle.colliderBox.Contains(mousePosition.X, mousePosition.Y))
                {
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
