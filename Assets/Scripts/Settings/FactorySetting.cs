using System.Collections.Generic;
using Asteroids.ConfigurationInfo;
using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "FactorySetting", menuName = "Settings/Factory", order = 0)]
    public class FactorySetting : ScriptableObject
    {
        public List<PlayerInformation> PlayerInformations = new List<PlayerInformation>();
        public List<UnitInformation> UnitInformations = new List<UnitInformation>();


        public void Create()
        {
            var list = new List<BaseConfigInformation<PlayerType, PlayerConfig>>() { };
            foreach (var information in PlayerInformations)
            {
                list.Add(information);
            }
        }

    }
}