using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Game_Jam
{
    class Scene
    {
        private Entity[] _entities;
        private Vector2 WorldPosition;
        public Entity[] Entities { get { return _entities; } }
        public bool Started { get; private set; }
        public Scene() { _entities = new Entity[0]; }
        public void Start()
        {
            Started = true;
        }
        public void Update()
        {
            for (int i = 0; i <_entities.Length; i++)
            {
                if (!_entities[i].Started)
                    _entities[i].Start();
                _entities[i].Update();
            }
        }
        public void Draw()
        {
            for (int i = 0; i < _entities.Length; i++)
            {
                _entities[i].Draw();
            }
        }
        public void End()
        {
            for (int i = 0; i < _entities.Length; i++)
            {
                if (_entities[i].Started)
                    _entities[i].End();
            }
        }
        public void AddEntity(Entity entity)
        {
            Entity[] temparray = new Entity[_entities.Length + 1];
            for (int i = 0; i < _entities.Length; i++) { temparray[i] = _entities[i]; }
            temparray[_entities.Length] = entity;
            _entities = temparray;
        }
        public bool RemoveEntity(Entity entity)
        {
            if (entity == null) { return false; }
            bool entityRemoved = false;
            Entity[] temparray = new Entity[_entities.Length - 1];
            int j = 0;
            for (int i = 0; i < _entities.Length; i++)
            {
                if (entity != _entities[i])
                {
                    temparray[j] = _entities[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                    if (entity.Started)
                        entity.End();
                }
            }
            _entities = temparray;
            return entityRemoved;
        }
        public bool TestCollision
        {

        }
    }
}
