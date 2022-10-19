using UnityEngine;

namespace Asteroids.Settings
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "Game/Settings", order = 0)]
    public class GameSetting : ScriptableObject
    {
        [field: SerializeField] public int FrameRate { get; private set; }
    }
}