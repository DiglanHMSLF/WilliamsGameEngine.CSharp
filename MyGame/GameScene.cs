using GameEngine;
using SFML.System;
namespace MyGame
{
    class GameScene : Scene
    {
        private int _score;
        public GameScene()
        {
            Ship ship = new Ship();
            AddGameObject(ship);
            MeteorSpawner meteorSpawner = new MeteorSpawner();
            AddGameObject(meteorSpawner);
        }
        // Get the current score
        public int GetScore()
        {
            return _score;
        }
        // Increase the score
        public void IncreaseScore()
        {
            ++_score;
        }
    }
}
