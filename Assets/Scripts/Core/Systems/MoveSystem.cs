using System.Collections.Generic;

namespace Asteroids.Core.Systems
{
    public class MoveSystem
    {
        public void Run(IEnumerable<IMover> elements, float deltaTime)
        {
            foreach (var element in elements)
            {
                element.Transform.position += element.Transform.forward * deltaTime * element.Speed;
            }
        }
    }
}