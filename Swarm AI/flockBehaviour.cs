using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flockBehaviour : MonoBehaviour {

    public float speed = 0.001f;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 15.0f;

    bool turning = false;

	// Use this for initialization
	void Start () {
        speed = Random.Range(0.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {

        if (Random.Range(0, 10) < 1)
        {
            FlockingRules();
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    void FlockingRules()
    {
        GameObject[] entityObjects;
        entityObjects = globalFlock.allEntities;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = globalFlock.goalPos;

        float dist;

        // For each boid's neighbour, avoid collision
        int groupSize = 0;
        foreach (GameObject obj in entityObjects)
        {
            if (obj != this.gameObject)
            {
                dist = Vector3.Distance(obj.transform.position, this.transform.position);

                if (dist <= neighbourDistance)
                {
                    vcentre += obj.transform.position;
                    groupSize++;

                    // To avoid collisions using transform
                    if (dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - obj.transform.position);
                    }

                    // Grabbing the flock behaviour of the neighbour
                    flockBehaviour anotherFlock = obj.GetComponent<flockBehaviour>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        // If the entity is in the group, calculate the average center and speed of the group
        if (groupSize > 0)
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            // Calculate the direction of the group
            Vector3 direction = (vcentre + vavoid) - transform.position;

            // If the direction does not equal to zero, the group will change direction without snapping it to the new direction
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }
        }
    } 
}
