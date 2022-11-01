using Asteroids.Settings;
using UnityEngine;

namespace Asteroids.Core
{
    public class Laser : BaseUnit
    {
        public Laser(LaserConfiguration configuration, WorldContainer worldContainer, MonoBehaviour view)
        {
            View = view;
            MoveComponent = new LaserMover(worldContainer.Player.RotationTransform, view.transform);
            ColliderComponent = new StandardCollider(view.transform, configuration.SizeCollision);
            CollisionChecker = new LaserCollisionChecker(worldContainer, ColliderComponent, configuration.Distance);
            CheckBorderComponent = new DummyCheckBorder();
            DestroyableComponent = new StandardDestroy(1, view);
            
            ResizeLaser((LaserView)View, configuration);
        }
        
        private void ResizeLaser(LaserView view, LaserConfiguration configuration)
        {
            view.Laser.transform.localScale = new Vector3(configuration.SizeCollision, configuration.Distance);
            view.Laser.transform.localPosition = new Vector3(0, configuration.Distance / 2 + 0.5f, 0);
        }
    }
}