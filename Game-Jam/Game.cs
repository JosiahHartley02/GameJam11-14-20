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
            AddScene(scene1);
            Player player = new Player(1, 1,'@', ConsoleColor.Red);
            scene1.AddEntity(player);
            Followers one = new Followers(2, 2, 'T', ConsoleColor.DarkYellow);
            scene1.AddEntity(one);
            Followers two = new Followers(3, 3, 'h', ConsoleColor.DarkYellow);
            scene1.AddEntity(two);
            Followers three = new Followers(4, 4, 'a', ConsoleColor.DarkYellow);
            scene1.AddEntity(three);
            Followers four = new Followers(5, 5, 'n', ConsoleColor.DarkYellow);
            scene1.AddEntity(four);
            Followers five = new Followers(6, 6, 'k', ConsoleColor.DarkYellow);
            scene1.AddEntity(five);
            Followers six = new Followers(7, 7, 'Y', ConsoleColor.DarkYellow);
            scene1.AddEntity(six);
            Followers seven = new Followers(8, 8, 'o', ConsoleColor.DarkYellow);
            scene1.AddEntity(seven);
            Followers eight = new Followers(9, 9, 'u', ConsoleColor.DarkYellow);
            scene1.AddEntity(eight);
            Followers nine = new Followers(10, 10, 'F', ConsoleColor.DarkYellow);
            scene1.AddEntity(nine);
            Followers ten = new Followers(11, 11, 'o', ConsoleColor.DarkYellow);
            scene1.AddEntity(ten);
            Followers eleven = new Followers(12, 12, 'r', ConsoleColor.DarkYellow);
            scene1.AddEntity(eleven);
            Followers twelve = new Followers(013, 013, 'P', ConsoleColor.DarkYellow);
            scene1.AddEntity(twelve);
            Followers thirteen = new Followers(014, 014, 'l', ConsoleColor.DarkYellow);
            scene1.AddEntity(thirteen);
            Followers fourteen = new Followers(015, 015, 'a', ConsoleColor.DarkYellow);
            scene1.AddEntity(fourteen);
            Followers fifteen = new Followers(016, 016, 'y', ConsoleColor.DarkYellow);
            scene1.AddEntity(fifteen);
            Followers sixteen = new Followers(017, 017, 'i', ConsoleColor.DarkYellow);
            scene1.AddEntity(sixteen);
            Followers seventeen = new Followers(018, 018, 'n', ConsoleColor.DarkYellow);
            scene1.AddEntity(seventeen);
            Followers eighteen = new Followers(019, 019, 'g', ConsoleColor.DarkYellow);
            scene1.AddEntity(eighteen);
            Followers nineteen = new Followers(20, 20, '!', ConsoleColor.DarkYellow);
            scene1.AddEntity(nineteen);
            _currentSceneIndex = 0;
            _scenes[_currentSceneIndex].Start();
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
