using System.Linq;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Movement Data", menuName = "Game Data/Movement Data", order = 3)]
    public class MovementData : ScriptableObject
    {
        public float speed;

        private static MovementData instance;
        public static MovementData Instance
        {
            get
            {
                if (!instance)
                    instance = Resources.FindObjectsOfTypeAll<MovementData>().FirstOrDefault();
                
                return instance;
            }
        }
    }
}
