using GameEngine;
using SFML.Graphics;
using SFML.System;
namespace MyGame
{
    class BackgroundGenerator : GameObject
    {
        // the number of milliseconds between meteor spans.
        private const int SpawnDelay = 1000;
        private int _timer;
        public override void Update(Time elapsed)
        {
            
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;
            
            if (_timer <= 0)
            {
                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;
                
                float bgX = size.X + 800;
                
                float bgY = Game.Random.Next() % size.Y;
                
                Background bg = new Background(new Vector2f(bgX, 0));
                Game.CurrentScene.AddGameObject(bg);
            }
        }
    }
}
