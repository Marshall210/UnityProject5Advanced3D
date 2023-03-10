using UnityEngine;

namespace GameData
{
    public class Environment : MonoBehaviour
    {
        public GroundData groundData;
        public AirData airData;

        public MovementData MovementData => MovementData.Instance;


        private void Update()
        {
            airData.windSpeed = Mathf.Sin(Time.time * airData.pressure) * 3;
        }
    }
}
