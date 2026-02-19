using UnityEngine;
using System.Collections;
using UnityEngine.UI.ProceduralImage;

public class MonkeyBlink : MonoBehaviour
{
    public Sprite openEyes;
    public Sprite closedEyes;

    private ProceduralImage img;

    void Start()
    {
        img = GetComponent<ProceduralImage>();
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 5f));

            img.sprite = closedEyes;
            yield return new WaitForSeconds(0.25f);

            img.sprite = openEyes;
        }
    }
}