using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Game_Jam
{
    class Player : Entity
    {
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x,y,icon,color)
        {
            LocalPosition = new Vector2(x, y);
            _defaultColor = color;
            _icon = icon;
        }
        private void Start()
    }
}
