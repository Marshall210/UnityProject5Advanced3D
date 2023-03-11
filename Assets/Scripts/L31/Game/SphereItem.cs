using UnityEngine;

public class SphereItem : MonoBehaviour
{
    public GameData.Environment environment;
    public float radius;
    private Vector3 pivot;
    
    private void Awake()
    {
        pivot = transform.position;

        GetComponent<Renderer>().material = environment.groundData.material;
    }

    private void Update()
    {
        transform.position = pivot;
        
        var speed = Time.time * environment.MovementData.speed;
        var sinPosition = Mathf.Sin(speed) * radius;
        var cosPosition = Mathf.Cos(speed) * radius;
        
        transform.position += new Vector3(cosPosition, sinPosition, 0);
        transform.position += new Vector3(environment.airData.windSpeed, environment.airData.temperature, 0);
    }
}