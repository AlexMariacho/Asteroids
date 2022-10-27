using Asteroids.Core.Weapons;
using UnityEngine;

namespace Asteroids.Core
{
    public class Laser : BaseUnit
    {
        public Laser(LaserConfiguration configuration, WorldContainer worldContainer, MonoBehaviour view)
        {
            View = view;
            MoveComponent = new LaserMover(worldContainer.Player.View.transform, view.transform);
            ColliderComponent = new StandardCollider(view.transform, configuration.SizeCollision);
            CollisionChecker = new LaserCollisionChecker(worldContainer, ColliderComponent, configuration.Distance);
            CheckBorderComponent = new DummyCheckBorder();
            DestroyableComponent = new LaserDestroy(view);
        }
    }
}