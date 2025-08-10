using System.Collections;
using UnityEngine;

public class SegmentGenerationManager : MonoBehaviour
{
    public GameObject[] segments;

    [SerializeField] int zPosition = 0;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;
    [SerializeField] int randSpawn;
    [SerializeField] bool spawnPowerUp = false;
    [SerializeField] int powerupChance = 10;
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
        segmentNum = Random.Range(0, 12);
        randSpawn = Random.Range(0, 100);
        if (randSpawn <= powerupChance) spawnPowerUp = true;
        if (spawnPowerUp)
        {
            segmentNum = Random.Range(9, 12);
            Instantiate(segments[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);
            spawnPowerUp = false;
        }
        else
        {
            Instantiate(segments[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);
        }
        zPosition += 20;
        yield return new WaitForSeconds(1.5f);
        creatingSegment = false;

    }
}
