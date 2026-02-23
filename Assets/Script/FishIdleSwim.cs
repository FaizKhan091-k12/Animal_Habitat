using UnityEngine;

public class FishIdleSwim : MonoBehaviour
{
    public float floatAmplitude = 10f;
    public float floatSpeed = 2f;

    public float swayAmplitude = 5f;
    public float swaySpeed = 3f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        float x = Mathf.Sin(Time.time * swaySpeed) * swayAmplitude;

        transform.localPosition = startPos + new Vector3(x, y, 0);
    }
}