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
/// Summary:displays win screen and disables player control when win conditions are met
/// </summary>
public class WinTrigger : MonoBehaviour {

    public Canvas WinScreen;

    private PlayerState pStateScript;

    void Start()
    {
        pStateScript = GameObject.Find("Player").GetComponent<PlayerState>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WinScreen.enabled = true;
            pStateScript.controlPlayer(false);
        }
    }
}
