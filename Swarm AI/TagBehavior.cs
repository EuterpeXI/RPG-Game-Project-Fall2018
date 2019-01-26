using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// An implementation of the flocking algorithm: http://www.red3d.com/cwr/boids/
// Additional resources:
// http://harry.me/2011/02/17/neat-algorithms---flocking/
public class TagBehavior : MonoBehaviour {
	/// <summary>
	/// the number of drones we want in this swarm
	/// </summary>
	public int droneCount = 30;
	public float spawnRadius = 50f;

	public List<GameObject> drones;
	
	public GameObject prefab;
	public GameObject[] staticObject;

	// Use this for initialization
	void Start () {
		if (prefab == null) {
			// end early
			Debug.Log("Please assign a drone prefab.");
			return;
		}

		// instantiate the drones
		GameObject droneTemp;
		ChildBehavior db = null;
		drones = new List<GameObject>();

		for (int i = 0; i < droneCount; i++) {
			droneTemp = (GameObject) GameObject.Instantiate(prefab);
			droneTemp.name = "Child " + i;
			db = droneTemp.GetComponent<ChildBehavior>();
			db.drones = this.drones;
			db.swarm = this;
			
			// spawn inside circle
			Vector2 pos = new Vector2(transform.position.x, transform.position.z) + Random.insideUnitCircle * spawnRadius;
			droneTemp.transform.position = new Vector3(pos.x, transform.position.y, pos.y);
			droneTemp.transform.parent = transform;
			drones.Add(droneTemp);

			db.maxRunSpeed = 3.0f + 1.5f * Random.value * Random.value;
			db.baseSpeed = db.maxRunSpeed * 0.75f;

		}

        /*
		droneTemp = drones[(int)(Random.value * drones.Count)];
		ChildBehavior.hunter = droneTemp;
		droneTemp.GetComponent<Renderer>().material.SetColor("_Color", Color.red);*/
	}
}