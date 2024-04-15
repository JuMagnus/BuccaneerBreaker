using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;



namespace BuccaneerBreaker
{
    public class Timer
    {
        private readonly Texture2D _texture;
        private readonly Vector2 _position;
        private readonly SpriteFont _font;
        private readonly Vector2 _textPosition;
        private string _text;
        public float timeLeft;
        private bool _isActive;

        public Timer(Texture2D texture, Vector2 position, SpriteFont font, float lenght)
        {
            _texture = texture;
            _position = position;
            _font = font;
            timeLeft = lenght;
            _textPosition = new(position.X + 150, position.Y + 30);
            _text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss\.ff");

        }

        private void FormatText()
        {
            _text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss\.ff");
        }

        public void StartStop()
        {
            _isActive = !_isActive; 
        }


        public void Update(GameTime gameTime)
        {
            if (!_isActive) return;
            timeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeLeft < 0 )
            {
                StartStop();
                timeLeft = 0;
            }
            FormatText();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _position, Color.White);
            spritebatch.DrawString(_font, _text, _textPosition, Color.Black);
        }

    }
}
