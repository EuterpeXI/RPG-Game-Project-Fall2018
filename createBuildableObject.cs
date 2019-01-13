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
/// Summary:This deals with crafting the items we need and subtracting the cost from the inventory
/// </summary>
public class createBuildableObject : MonoBehaviour
{
    private Sprite buildableImage;
    private int metalCost;
    private int rockCost;
    private int woodCost;
    private string buildableName;
    private bool crafted = false;
    private bool canCraftMultiple;
    private UILogicScript uiScript;
    private int totalBuilt = 0;
    private objectivesLogic objectiveScript;
    private string actionType;

    public Image currentImage;
    public Text nameTextField;
    public Text ownedField;
    public Text woodText;
    public Text metalText;
    public Text rockText;

    private void Start()
    {
        uiScript = GameObject.Find("UILogic").GetComponent<UILogicScript>();
        objectiveScript = GameObject.Find("QuestPanel").GetComponent<objectivesLogic>();
    }

    //could remove this but idgaf
    private void Update()
    {
        ownedField.text = "Owned: " + totalBuilt.ToString();
    }

    /*
     * This sets the cost for the respective items to be crafted.
     */ 
    public void populateCosts(int metalCost, int rockCost, int woodCost)
    {
        this.metalCost = metalCost;
        this.rockCost = rockCost;
        this.woodCost = woodCost;

        woodText.text += woodCost.ToString();
        metalText.text += metalCost.ToString();
        rockText.text += rockCost.ToString();
    }

    /*
     * This function sets the name of the craftable
     */ 
    public void setName(string val)
    {
        this.buildableName = val;
        nameTextField.text = this.buildableName;
    }

    /*
     * This function returns the name of the craftable
     */ 
    public string getName()
    {
        return this.buildableName;
    }

    /*
     * This function sets the image of the craftable
     */ 
    public void setImage(Sprite image)
    {
        this.buildableImage = image;
        currentImage.sprite = this.buildableImage;
    }

    /*
     * This function gathers the resources from the inventory and calls on the function to craft
     */ 
    public void callCraft()
    {
        int Metal = uiScript.getResourceCount("Metal");
        int Wood = uiScript.getResourceCount("Wood");
        int Rock = uiScript.getResourceCount("Rock");

        craftObject(Metal, Rock, Wood);
    }

    /*
     * This function checks to see if the object can be crafted and if multiple of the object can be crafted. If so,
     * it will set the crafted boolean of the object to true and build it. Once finished, it will subtract the resources
     * from the inventory and calls upon handleBoolean to set the object crafted to true.
     */ 
    public void craftObject(int metalVal, int rockVal, int woodVal)
    {
        //check if already crafted and can be crafted multiple times
        if (crafted && canCraftMultiple)
        {
            // Check to see if the player has enough material
            if (metalVal >= metalCost && rockVal >= rockCost && woodVal >= woodCost)
            {
                print("CRAFTING!");
                crafted = true;
                totalBuilt++;

                //subtract from total resources
                uiScript.editResource("Metal", -metalCost);
                uiScript.editResource("Wood", -woodCost);
                uiScript.editResource("Rock", -rockCost);

                // Set the object crafted to true
                handleBoolean(actionType);
            }
            else
            {
                // Else, they do not have enough materials
                print("NOT ENOUGH MINERALS");
            }
        }
        // If the item has never been crafted, make it
        else if (!crafted)
        {
            if (metalVal >= metalCost && rockVal >= rockCost && woodVal >= woodCost)
            {
                print("CRAFTING!");
                crafted = true;
                totalBuilt++;

                uiScript.editResource("Metal", -metalCost);
                uiScript.editResource("Wood", -woodCost);
                uiScript.editResource("Rock", -rockCost);

                handleBoolean(actionType);
            }
            else
            {
                print("NOT ENOUGH MINERALS");
            }
        }

    }

    /*
     * This function handles the boolean of the respective string value to true once they are crafted.
     */ 
    private void handleBoolean(string val)
    {
        // If the bridge planks are made, then set the bool value within the objective script to true
        if (val == "bridgePlanks")
        {
            objectiveScript.setBridgePlanksMade(true);
        }
        // If the Pickaxe are made, then set the bool value within the objective script to true
        else if (val == "pickaxe")
        {
            objectiveScript.setPickaxeMade(true);
        }
        // If the Axe are made, then set the bool value within the objective script to true
        else if (val == "axe")
        {
            objectiveScript.setAxeMade(true);
        }
        // If the Solar Panel are made, then set the bool value within the objective script to true
        else if (val == "solarPanel")
        {
            objectiveScript.setSolarPanelMade(true);
        }
    }

    /*
     * This function handles the contents of each craftable and populates their costs.
     */ 
    public void setAction(string val)
    {
        if (val == "Pickaxe")
        {
            populateCosts(5, 0, 5);
            crafted = false;
            actionType = "pickaxe";
            //set overall logic to say that bridge can be built 
        }
        else if (val == "Axe")
        {
            populateCosts(0, 5, 5);
            crafted = false;
            actionType = "axe";
            //set overall logic to say that bridge can be built 
        }
        else if (val == "Solar Panel")
        {
            populateCosts(30, 30, 30);
            crafted = false;
            canCraftMultiple = true;
            actionType = "solarPanel";
            //call playerlogic to increase rate of regen
        }
        else if (val == "Bridge Planks")
        {
            //populateCosts(75, 0, 15);
            populateCosts(10, 0, 15);
            crafted = false;
            actionType = "bridgePlanks";
            //set overall logic to say that bridge can be built 
        }
        else if (val == "Jetpack Boots")
        {
            populateCosts(150, 15, 200);
            crafted = false;
            canCraftMultiple = false;
            actionType = "jetpackBoots";

            //change player script to jump higher
        }
    }

    /*
     * This function returns the "action type" which is the item
     * to be crafted.
     */ 
    public string getActionType()
    {
        return this.actionType;
    }

    /*
     * This function returns a boolean to signify if the item has 
     * been built
     */ 
    public bool isBuilt()
    {
        return crafted;
    }






}
