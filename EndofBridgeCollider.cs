using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Zachary Shaw
/// Amelia Chin
/// Waldo Lane
/// Nolan Mushtuk
/// Nicholas Brunnenkant
/// Date:December 14 2018
/// Summary:This deals with wether or not that player has fixed the bridge to finish the quest in quest logic
/// </summary>
public class EndofBridgeCollider : MonoBehaviour {

    private bool passed = false;

    /*
     * If the player enters the zone, then we mark the boolean as true
     */ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            passed = true;
        }
    }

    /*
     * This function sends the boolean value to our objectivesLogic script to
     * activate the fourth quest.
     */ 
    public bool get_trigger()
    {
        return passed;
    }
}
