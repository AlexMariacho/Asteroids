using UnityEngine;

namespace Asteroids.Core.Views
{
    public class PlayerView : BaseGameObjectView
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 direction = transform.TransformDirection(Vector3.up) * 15;
            Gizmos.DrawSphere(transform.position + direction, 1);
        }
    }
}