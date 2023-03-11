using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Ground Data", menuName = "Game Data/Ground Data", order = 1)]
    public class GroundData : ScriptableObject
    {
        public float friction;
        public float bounciness;
        public Material material;
    }
}
