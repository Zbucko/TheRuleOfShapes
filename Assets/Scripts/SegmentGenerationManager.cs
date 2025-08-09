using System.Collections;
using UnityEngine;

public class SegmentGenerationManager : MonoBehaviour
{
    public GameObject[] segments;

    [SerializeField] int zPosition = 0;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 8);
        Instantiate(segments[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);
        zPosition += 20;
        yield return new WaitForSeconds(1.5f);
        creatingSegment = false;

    }
}
