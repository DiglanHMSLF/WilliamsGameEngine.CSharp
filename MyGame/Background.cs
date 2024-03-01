using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace MyGame
{
    class Background : GameObject
    {
        private float MSpeed = 0.5f;

        private readonly Sprite _bg = new Sprite();
        
        public Background(Vector2f pos)
        {
            _bg.Texture = Game.GetTexture("../../../Resources/background.png");
            _bg.Position = pos;
            

            AssignTag("background");

        }

       

        public override void Draw()
        {
            Game.RenderWindow.Draw(_bg);
        }

        public override void Update(Time elapsed)
        {

            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _bg.Position;

            if (pos.X < _bg.GetGlobalBounds().Width * -1)
            {

                MakeDead();
            }
            else
            {
                _bg.Position = new Vector2f(pos.X - MSpeed * msElapsed, pos.Y);
            }
        }
    }
}


    

