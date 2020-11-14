using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Game_Jam
{
    class Followers : Entity
    {
        bool _isVisible;
        char Icon;
        bool isFollowing;
        int _pointsForVisible;
        public int PointsForVisible;
        public bool IsVisible { get { return _isVisible; } }
        public Followers (float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base (x,y,icon,color)
        {
            LocalPosition = new Vector2(x, y);
            _icon = icon;
            _defaultColor = color;
        }
        public override void Start()
        {
            _pointsForVisible = Game.GetCurrentScene().Entities[Game.GetCurrentScene().Entities.Length].PointsForVisible + 1;
            base.Start();
        }
        public override void Update()
        {   
            if(_pointsForVisible == Game.GetPoints())
            {
                _isVisible = true;
            }
            if(_parent != null)
            {
                LocalPosition = _parent.OldPosition;
            }
            if (TestCollision() == true && _isVisible == true)
            {
                Game.AddPoint();
            }
        }
        public override void Draw()
        {
            if (_isVisible) { base.Draw(); }            
        }
        public override void End()
        {
            base.End();
        }
    }
}
