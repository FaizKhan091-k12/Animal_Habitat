using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloundGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    [SerializeField] Transform clonePos;

    void Start()
    {
        InvokeRepeating(nameof(GenerateClouds), 1, UnityEngine.Random.Range(10 , 20));
    }

    public void GenerateClouds()
    {
        int randomeCloud = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloudsClone = Instantiate(clouds[randomeCloud], new Vector3(clonePos.position.x,
        UnityEngine.Random.Range(clonePos.position.y,clonePos.position.y),clonePos.position.z), Quaternion.identity);
        cloudsClone.transform.SetParent(clonePos);
        
        cloudsClone.GetComponent<RectTransform>().pivot = new Vector2(0, Random.Range(1,2.2f));
        float randomCloudScale = Random.Range(.5f, 1f);
        cloudsClone.transform.localScale = new Vector3((float)randomCloudScale,(float)randomCloudScale,(float)randomCloudScale);
        Destroy(cloudsClone, 100f);
    }
}
