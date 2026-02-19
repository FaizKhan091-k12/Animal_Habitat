using UnityEngine;

public class MonkeyIdle : MonoBehaviour
{
    Vector3 startPos;
    Vector3 startScale;

    void Start()
    {
        startPos = transform.localPosition;
        startScale = transform.localScale;
    }

    void Update()
    {
        // Gentle float
        float floatY = Mathf.Sin(Time.time * 1.5f) * 5f;
        transform.localPosition = startPos + new Vector3(0, floatY, 0);

        // Breathing
        float breathe = 1f + Mathf.Sin(Time.time * 2f) * 0.03f;
        transform.localScale = startScale * breathe;
    }
}