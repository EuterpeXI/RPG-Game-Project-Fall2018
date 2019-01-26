using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source code: https://www.youtube.com/watch?v=eMpI1eCsIyM
public class globalFlock : MonoBehaviour {

    public GameObject entityPrefab;
    public static int areaSize = 10;

    static int numEntities = 31;
    public static GameObject[] allEntities = new GameObject[numEntities];

    public static Vector3 goalPos = Vector3.zero;

    // Use this for initialization
    void Start() {
        // Adding in the clones for the boids.
        for (int i = 0; i < numEntities; i++)
        {
            // Initialize the boids at this position
            Vector3 pos = new Vector3(Random.Range(-areaSize, areaSize) + 210, Random.Range(-areaSize, areaSize) + 100, Random.Range(-areaSize, areaSize) + 250);
            allEntities[i] = (GameObject)Instantiate(entityPrefab, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        // Create a randomized "goal position" for the swarm to head towards 
		if (Random.Range(0,1000) < 50)
        {
            goalPos = new Vector3(Random.Range(-areaSize, areaSize) + 200, Random.Range(-areaSize, areaSize) + 100, Random.Range(-areaSize, areaSize) + 250);
        }
    }
}
