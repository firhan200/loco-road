using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    [Header("Obstacle")]
    public GameObject track1Car;
    public GameObject track2Car;

    [Header("Spawn Time")]
    public float track1SpawnTime;
    public float track2SpawnTime;

    bool isTrack1Spawning;
    bool isTrack2Spawning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTrack1Spawning)
        {
            StartCoroutine(SpawnTrack1Car());
            GameObject car1 = Instantiate(track1Car);
            car1.transform.position = new Vector3(-35f, transform.position.y, transform.position.z - 3);
        }

        if (!isTrack2Spawning)
        {
            StartCoroutine(SpawnTrack2Car());
            GameObject car2 = Instantiate(track2Car);
            car2.transform.position = new Vector3(-35f, transform.position.y, transform.position.z + 3);
        }
    }

    IEnumerator SpawnTrack1Car()
    {
        isTrack1Spawning = true;

        yield return new WaitForSeconds(track1SpawnTime);

        isTrack1Spawning = false;
    }

    IEnumerator SpawnTrack2Car()
    {
        isTrack2Spawning = true;

        yield return new WaitForSeconds(track2SpawnTime);

        isTrack2Spawning = false;
    }
}
