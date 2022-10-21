using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "Settings/Game Settings", order = 0)]
    public class GameSetting : ScriptableObject
    {
        [field: SerializeField] public int FrameRate { get; private set; }
    }
}