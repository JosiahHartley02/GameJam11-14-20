using System;

namespace MathLibrary
{
    public class Vector2
    {
        private float _x;
        private float _y;
        public Vector2(float x, float y)
        { _x = x; _y = y; }
        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        { return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y); }
    }
}
