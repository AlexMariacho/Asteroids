using System;
using UnityEngine;

namespace Asteroids.Core
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/Bullet", order = 0)]
    public class BulletConfig : ScriptableObject
    {
        public GameObject View;
        public float Radius;
        public float Speed;
        public int Damage;
    }
}