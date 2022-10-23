using System;
using UnityEngine;

namespace Asteroids.Core
{
    [Serializable]
    public class PositionComponent : IData
    {
        public Vector2 Position;
        public Vector2 Rotation;
    }
}