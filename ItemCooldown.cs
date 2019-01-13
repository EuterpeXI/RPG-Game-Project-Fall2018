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
/// Summary:This handles the items cooldown on the GUI item bar showing what is being used and hw long to wait until next use
/// </summary>
public class ItemCooldown : MonoBehaviour {

    public Image pickaxe_image;
    public Image axe_image;

    private objectivesLogic objectiveScript;
    private GameObject player;
    private Animator m_Animator;
    private bool active = false;
    private bool hasPickaxe = false;
    private bool hasAxe = false;
    private bool isFilled = false;


	// Use this for initialization
	void Start () {
        objectiveScript = GameObject.Find("QuestPanel").GetComponent<objectivesLogic>();
        player = GameObject.FindGameObjectWithTag("Player");
        m_Animator = player.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        hasPickaxe = objectiveScript.get_pickAxeBool();
        hasAxe = objectiveScript.get_axeBool();

        // If player has the tools, then whenever the player harvests, we want to set a cooldown
        if (hasPickaxe && hasAxe)
        {
            // If the player is harvesting
            if (m_Animator.GetBool("isHarvesting") && !active)
            {
                StartCoroutine(cooldown(1));
            }
            if (pickaxe_image.fillAmount == 0)
            {
                isFilled = false;
            }
        }

		// Want to check if harvesting with tool. If harvesting, begin at fill ammount
        // of 1 and decrease over time that is synced with the animation
	}

    /*
     * Function to handle filling of the amount
     */ 
    private void fill()
    {
        pickaxe_image.fillAmount = 1;
        axe_image.fillAmount = 1;
        isFilled = true;
    }

    /*
     * Function to handle cooldown
     */ 
    IEnumerator cooldown(float n)
    {
        active = true;
        if (!isFilled)
        {
            fill();
        }
        pickaxe_image.fillAmount -= 0.1f;
        axe_image.fillAmount -= 0.1f;

        yield return new WaitForSeconds(n);
        active = false;
    }
}
