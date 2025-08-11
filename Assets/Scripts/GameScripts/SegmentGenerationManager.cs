using System.Collections;
using UnityEngine;

public class SegmentGenerationManager : MonoBehaviour
{
    //Array of segments used for generation.
    public GameObject[] segments;

    //Start position.
    [SerializeField] int zPosition = 0;

    //Check if a segment is being created, if so, dont create another one in its place.
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;
    [SerializeField] int randSpawn;

    //The chance of powerups appearing.
    [SerializeField] int powerupChance = 35;
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
        //Generate a random segment number.
        segmentNum = Random.Range(0, 14);

        //If its a segment with a powerup, generate a random number between 0 and 100, using chance to create powerup segments.
        if (segmentNum >= 9 && segmentNum < 14)
        {
            
            randSpawn = Random.Range(0, 101);

            //If random number is lower than powerup chance, generate powerup segment, if not, generate a random normal segment.
            if (randSpawn <= powerupChance)
            {
                Instantiate(segments[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);
            }
            else
            {
                segmentNum = Random.Range(0, 9);
                Instantiate(segments[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);
            }
        }
        else
        {
            Instantiate(segments[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);
        }

        //Move the spawn postion by 20.
        zPosition += 20;
        
        //Create a segment every 1.5 seconds.
        yield return new WaitForSeconds(1.5f);
        creatingSegment = false;

    }
}
