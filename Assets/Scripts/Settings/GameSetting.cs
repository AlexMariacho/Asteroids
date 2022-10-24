using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "Settings/Game Settings", order = 0)]
    public class GameSetting : ScriptableObject
    {
        public int FrameRate;
    }
}