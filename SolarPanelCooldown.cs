using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Zachary Shaw
/// Amelia Chin
/// Waldo Lane
/// Nolan Mushtuk
/// Nicholas Brunnenkant
/// Date:December 14 2018
/// Summary:Deals entirely with the cooldown of the solar panels to show when they are generating energy for the player
/// </summary>
public class SolarPanelCooldown : MonoBehaviour {

    public Image solarImage;

    private objectivesLogic objectiveScript;
    private PlayerState playerstateScript;
    private OrbitScript sunScript;
    private bool hasSolarPanel = false;
    private bool active = false;
    private bool isDay = false;

    // Use this for initialization
    void Start () {
        objectiveScript = GameObject.Find("QuestPanel").GetComponent<objectivesLogic>();
        playerstateScript = GameObject.Find("Player").GetComponent<PlayerState>();
        sunScript = GameObject.Find("Sun").GetComponent<OrbitScript>();
    }
	
	// Update is called once per frame
	void Update () {
        // Check to see if the player has the solar panel
        hasSolarPanel = objectiveScript.get_solarBool();

        // Once the solar amount is crafted, we can begin its functions
        if (hasSolarPanel)
        {
            // Check if it is daytime
            isDay = sunScript.isDayRightNow();

            // If the cooldown is not active and its day time, make it active
            // We begin the game with fillAmount = 1
            if (!active && isDay)
            {
                StartCoroutine(cooldown(1));
            }

            // Once the cooldown is finished and its day time, we want to add power to the battery then restart the 
            if (solarImage.fillAmount == 0 && isDay)
            {
                playerstateScript.addLife(0.1f); // Filling the battery by a certain rate
                solarImage.fillAmount = 1; // Reset the fillAmount to restart CD
            }
        }

    }

    /*
     * This IEnumerator handles the decreasing fillamount over time. In other words, the cooldown.
     */ 
    IEnumerator cooldown(float n)
    {
        active = true;
        solarImage.fillAmount -= 0.1f;

        yield return new WaitForSeconds(n);
        active = false;
    }
}
