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
/// Summary:This handles the object GUI along with the checking if the player has completed an objective in the world and handles what conditions are finished and left to be completed
/// </summary>
public class objectivesLogic : MonoBehaviour {

    public Image pickaxe_image;
    public Image axe_image;

    private bool pickaxe = false;
    private bool axe = false;
    private bool bridgePlanks = false;
    private bool solarPanel = false;
    private bool firstQ = false;
    private bool secondQ = false;
    private bool thirdQ = false;
    private bool bridgeTrigger = false;
    private Text OBtext;
    private EndofBridgeCollider bridgeCollider;

    void Start()
    {
        bridgeCollider = GameObject.Find("EndofBridgeBox").GetComponent<EndofBridgeCollider>();
        OBtext = GameObject.Find("ObjectiveContentsText").GetComponent<Text>();
        firstQuest(); // Start the first quest
    }

    void Update()
    {
        // If both items have been made, the first quest is finished
        if (pickaxe && axe)
        {
            firstQ = true;
            pickaxe_image.fillAmount = 0;
            axe_image.fillAmount = 0;
        }

        // If solar panels have been made, second quest is finished
        if (solarPanel)
        {
            secondQ = true;
        }

        // If bridge planks are made, third quest is completed
        if (bridgePlanks)
        {
            thirdQ = true;
        }


        // If first quest is completed call the second quest
        if (firstQ)
        {
            secondQuest();
        }

        // If the second quest is completed call the third quest
        if (secondQ)
        {
            thirdQuest();
        }

        // If the third quest is completed, activate the final objective
        if (thirdQ)
        {
            OBtext.text = "Use the wooden planks to repair the bridge and cross it.";
        }

        bridgeTrigger = bridgeCollider.get_trigger();
        if (bridgeTrigger)
        {
            forthQuest();
        }
    }

    /*
     * This function handles the first quest. The first quest/objective is to create the pickaxe and axe.
     */
    private void firstQuest()
    {
        OBtext.text = "Open inventory (I) to craft a Pickaxe and an axe. \nPickaxe: \n\t5 metals\n\t5 wood\nAxe: \n\t5 wood\n\t5 rocks";
    }

    /*
     * This function handles the second quest. This is where the player will build a solar panel to recharge energy.
     */ 
    private void secondQuest()
    {
        OBtext.text = "You will need some way to regenerate power during the day. \nCollect the following materials to build a solar panel.\n\t30 metals\n\t30 wood\n\t30 rocks";
    }

    /*
     * This function handles the third quest. This is where the player should create the wooden planks to get across the bridge.
     */ 
    private void thirdQuest()
    {
        OBtext.text = "You need to repair the bridge to cross it! \nCollect the following materials to build the wooden planks:\n\t10 metals\n\t15 wood";
    }

    private void forthQuest()
    {
        OBtext.text = "Make your way to the city!";
    }

    /*
     * This function sets the boolean for wood planks to signify if the object has been created or not.
     */
    public void setBridgePlanksMade(bool val)
    {
        this.bridgePlanks = val;
    }

    /*
     * This function sets the boolean for pickaxe to signify if the object has been created or not.
     */
    public void setPickaxeMade(bool val)
    {
        this.pickaxe = val;
    }

     /*
     * This function sets the boolean for axe to signify if the object has been created or not.
     */ 
    public void setAxeMade(bool val)
    {
        this.axe = val;
    }

    /*
     * This function sets the boolean for solar panel to signify if the object has been created or not.
     */ 
    public void setSolarPanelMade(bool val)
    {
        this.solarPanel = val;
    }

    /*
     * This function returns the solar panel boolean
     */ 
    public bool get_solarBool()
    {
        return solarPanel;
    }

    /*
    * This function returns the bridge plank boolean
    */
    public bool bridgePlanksMade()
    {
        return this.bridgePlanks;
    }

    /*
     * This function returns the pickaxe boolean
     */
    public bool get_pickAxeBool()
    {
        return pickaxe;
    }

    /*
     * This function returns the axe boolean
     */ 
    public bool get_axeBool()
    {
        return axe;
    }
}
