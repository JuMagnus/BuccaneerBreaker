using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace BuccaneerBreaker
{
    public class SceneChoosePaddle : Scene
    {
        
        private IAssets _assets = ServicesLocator.Get<IAssets>();
        private IInputs _inputs = ServicesLocator.Get<IInputs>();
        private ISceneManager _sceneManager = ServicesLocator.Get<ISceneManager>();
        private IScreen _screen = ServicesLocator.Get<IScreen>();
        private IPaddle _paddle = ServicesLocator.Get<IPaddle>();

        private Sprite _background;
        private Button _cannonBall;
        private Button _gunner;
        private SoundEffect _clickButton;



        //J'aurais aimé regrouper les créations de boutons au sein d'une même boucle for mais les différences entre eux m'ont gêné.
        //Peut être en faisant autant de listes et en parcourant plusieurs listes en même temps, comme pour l'attaque spéciale du gunner.
        public override void Load()
        {
            _background = new Sprite(Vector2.Zero, _assets.Get<Texture2D>("TexPaddleType"));
            AddSprite(_background);

            _cannonBall = new Button(new Rectangle((int)_screen.Center.X - 275, (int)_screen.Center.Y - 100, 550, 100), Color.White, _assets.Get<SpriteFont>("FontTradeWind"), "CANNONBALL");
            AddSprite(_cannonBall);

            _gunner = new Button(new Rectangle((int)_screen.Center.X - 275, (int)_screen.Center.Y + 100, 550, 100), Color.White, _assets.Get<SpriteFont>("FontTradeWind"), "GUNNER");
            AddSprite(_gunner);
            
            _clickButton = _assets.Get<SoundEffect>("SoundClic");
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);

            //Si j'arrive à mettre la création des boutons dans une boucle (et donc dans une liste), je pourrais simplifier également cette partie, comme dans la scène LevelSelection

            if (_inputs.IsMouseLeftClicked())
            {
                Vector2 mousePosition = _inputs.GetMousePosition();
                _clickButton.Play();
                if (_cannonBall.colliderBox.Contains(mousePosition.X, mousePosition.Y))
                {
                    _paddle.currentType = "cannonBall";                    
                    _sceneManager.Load(typeof(SceneLevelSelection));
                }
                else if (_gunner.colliderBox.Contains(mousePosition.X, mousePosition.Y))
                {
                    _paddle.currentType = "gunner";
                    _sceneManager.Load(typeof(SceneLevelSelection));
                }
            }



        }

    }
}
