using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Game_Jam
{
    class Entity
    {
        protected char _icon;
        protected ConsoleColor _defaultColor;
        protected Vector2 _velocity;
        protected Entity _parent;
        protected Entity[] _children;
        protected bool isChild = false;
        public bool Started { get; private set; }
        public Vector2 LocalPosition;
        public Vector2 WorldPosition;
        public Entity(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            LocalPosition = new Vector2(x, y);
            _icon = icon;
            _defaultColor = color;
        }
        public virtual void Start() { Started = true; }
        public virtual void Update()
        {
            LocalPosition += _velocity;
        }
        public virtual void Draw()
        {
            Console.ForegroundColor = _defaultColor;
            if (WorldPosition.X >=0 && WorldPosition.X < Console.WindowWidth && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
            { Console.SetCursorPosition((int)WorldPosition.X,(int)WorldPosition.Y); }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public virtual void End()
        {
            Started = false;
        }
        public Vector2 Velocity
        {
            get { return _velocity; }
        }
        public void AddChild(Entity child)
        {
            Entity[] tempArray = new Entity[_children.Length + 1];
            for(int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }
            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
            this.isChild = true;
        }
        public bool RemoveChild(Entity child)
        {
            if (child == null) { return false; }
            bool childRemoved = false;
            Entity[] tempArray = new Entity[_children.Length - 1];
            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else { childRemoved = true; }
            }
            _children = tempArray;
            child._parent = null;
            this.isChild = false;
            return childRemoved;
        }
        public void SetLocalPosition(Vector2 position) { LocalPosition = position; }
    }
}
