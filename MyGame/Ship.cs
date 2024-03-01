using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Security.Cryptography.X509Certificates;

namespace MyGame
{
    class Ship : GameObject
    {
        private const float Speed = 0.5f;
        private const int FireDelay = 200;
        private int _fireTimer;

        private bool doubleShot = true;
        private bool tripleShot = false;



        private readonly Sprite _sprite = new Sprite();

        // Creates our ship.
        public Ship()
        {
            _sprite.Texture = Game.GetTexture("../../../Resources/shuttleASE.png");

            _sprite.Position = new Vector2f(100, 100);
            
        }
        // functions overridden from GameObject:
        public override void Draw()
        {
             Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            
            Vector2f pos = _sprite.Position;


            float x = pos.X;
            float y = pos.Y;
            int msElapsed = elapsed.AsMilliseconds();
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) { y -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) { y += Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { x += Speed * msElapsed; }
            _sprite.Position = new Vector2f(x, y);
            if (_fireTimer > 0) { _fireTimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                if(doubleShot == false && tripleShot == false)
                {
                    _fireTimer = FireDelay;
                    FloatRect bounds = _sprite.GetGlobalBounds();
                    float laserX = x + bounds.Width;
                    float laserY = y + bounds.Height / 2.0f;
                    Laser laser = new Laser(new Vector2f(laserX, laserY));
                    Game.CurrentScene.AddGameObject(laser);
                }

                if(doubleShot == true && tripleShot == false)
                {
                    _fireTimer = FireDelay;
                    FloatRect bounds = _sprite.GetGlobalBounds();
                    float laserX = x + bounds.Width;
                    float laserY = y + bounds.Height / 2 - 20;
                    float laserX2 = x + bounds.Width;
                    float laserY2 = y + bounds.Height / 2 + 20;
                    Laser laser = new Laser(new Vector2f(laserX, laserY));
                    Laser laser2 = new Laser(new Vector2f(laserX2, laserY2));
                    Game.CurrentScene.AddGameObject(laser);
                    Game.CurrentScene.AddGameObject(laser2);

                    
                }

            }


        }
    }
}
