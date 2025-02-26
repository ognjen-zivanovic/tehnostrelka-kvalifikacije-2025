using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject container;

    private float timeRemainingUntillSpawn = 5.0f;
    public float minTime = 5.0f;
    public float maxTime = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeRemainingUntillSpawn -= Time.deltaTime;
        if (timeRemainingUntillSpawn <= 0.0f) {
            timeRemainingUntillSpawn = Random.Range(minTime, maxTime);
            // position is between the bounds defined in WaterBoundsInfo
            Vector3 position = new Vector3(Random.Range(WaterBoundsInfo.minX, WaterBoundsInfo.maxX), 0.0f, Random.Range(WaterBoundsInfo.minZ, WaterBoundsInfo.maxZ));
            while (position.x * position.x + position.z * position.z < 0.5 * 0.5) {
                position = new Vector3(Random.Range(WaterBoundsInfo.minX, WaterBoundsInfo.maxX), 0.0f, Random.Range(WaterBoundsInfo.minZ, WaterBoundsInfo.maxZ));
            }
            // rotation is random
            Quaternion rotation = Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
            
            GameObject newObject = Instantiate(obstaclePrefab, container.transform);
            newObject.transform.localPosition = position;
            newObject.transform.localRotation = rotation;
            Debug.Log("Spawned: " + newObject.name);
        }
    }
}
