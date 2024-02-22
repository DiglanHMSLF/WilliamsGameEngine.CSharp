using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace MyGame
{
    class Ship : GameObject
    {
        private readonly Sprite _sprite = new Sprite();
        // Creates our ship.
        public Ship()
        {
            _sprite.Texture = Game.GetTexture("Resources/ship.png");
            _sprite.Position = new Vector2f(100, 100);
        }
        // functions overridden from GameObject:
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position; // had to add something
        }
    }
}
