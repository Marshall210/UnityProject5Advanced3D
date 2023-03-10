using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Air Data", menuName = "Game Data/Air Data", order = 2)]
    public class AirData : ScriptableObject
    {
        public float temperature;
        public float pressure;
        public float windSpeed;

        // public Temp[] array;

        // [Serializable]

        // public class Temp{
        //     public GameObject t;
        //     public float speed;
        //     public Material mat;
        // }
    }
}
