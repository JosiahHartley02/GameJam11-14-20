using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game_Jam
{
    class Game
    {
        private static int _points;
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;
        public Game() { _scenes = new Scene[0]; }
        public void Start()
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 140;
            Scene scene1 = new Scene();
        }
        public void Update()
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();
            _scenes[_currentSceneIndex].Update();
        }
        public void Draw()
        {
            _scenes[_currentSceneIndex].Draw();
        }
        public void End()
        {
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
        }
        public void Run()
        {
            Start();
            while(!_gameOver)
            {
                Update();
                Draw();
                Thread.Sleep(250);
            }
        }
        public static int CurrentSceneIndex
        { get { return _currentSceneIndex; } }
        public static void SetGameOver(bool value)
        { _gameOver = value; }
        public static Scene GetCurrentScene()
        { return _scenes[_currentSceneIndex]; }
        public static int AddScene(Scene scene)
        {
            if (scene == null) { return -1; }
            Scene[] tempArray = new Scene[_scenes.Length + 1];
            for (int i = 0; i < _scenes.Length; i++) { tempArray[i] = _scenes[i]; }
            int index = _scenes.Length;
            tempArray[index] = scene;
            _scenes = tempArray;
            return index;
        }
        public static bool RemoveScene(Scene scene)
        {
            if (scene == null) { return false; }
            bool sceneRemoved = false;
            Scene[] tempArray = new Scene[_scenes.Length - 1];
            int j = 0;
            for (int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else { sceneRemoved = true; }
            }
            if (sceneRemoved) { _scenes = tempArray; }
            return sceneRemoved;
        }
        public static ConsoleKey GetNextKey()
        {
            if (!Console.KeyAvailable) { return 0; }
            return Console.ReadKey(true).Key;
        }
        public static bool IsKeyDown(ConsoleKey key)
        {
            if(Console.ReadKey(true).Key != key)
            {
                return false;
            }
            return true;
        }
        public static void AddPoint()
        {
            _points++;
        }
        public static int GetPoints()
        {
            return _points;
        }
        public static void SetGameOver()
        {
            _gameOver = true;
        }
    }
}
