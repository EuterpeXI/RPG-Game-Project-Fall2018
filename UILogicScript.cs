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
/// Summary:Deals with UI layout updating and handling of UI events along with Button clicks this is the main UI handler script
/// </summary>
public class UILogicScript : MonoBehaviour
{

    public Text metalText;
    public Text rockText;
    public Text woodText;
    public Canvas inventoryOverlay;

    private int metalCount;
    private int rockCount;
    private int woodCount;
    private string metal = "Metal: ";
    private string rock = "Rock: ";
    private string wood = "Wood: ";
    private GameObject player;
    private bool canControl;
    private PlayerState playerStateScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStateScript = player.GetComponent<PlayerState>();
        editResource("Wood", 10);
        editResource("Rock", 5);
        editResource("Metal", 5);
        //inventoryOverlay.enabled = false;
    }

    //consistently updates the text for the UI to set it
    void Update()
    {
        setText("Metal");
        setText("Rock");
        setText("Wood");
        // calls function to toggle invntory canvas if user presses the proper key
        if (getUserInput("i"))
        {
            handleInventoryToggle();

        }

    }
    //disables user control of player and enables inventory canvas or disables the canvas and reinables player control when called
    private void handleInventoryToggle()
    {
        if (inventoryOverlay.enabled)
        {
            inventoryOverlay.enabled = false;
            playerStateScript.controlPlayer(true);
        }
        else
        {
            inventoryOverlay.enabled = true;
            playerStateScript.controlPlayer(false);

        }
    }
    // returns any key pressed by user 
    private bool getUserInput(string Button)
    {
        if (Input.GetKeyDown(Button))
        {
            return true;
        }

        return false;
    }
    // returns owned number of each resource
    public int getResourceCount(string resource)
    {
        switch (resource)
        {
            case "Metal":
                return metalCount;

            case "Rock":
                return rockCount;

            case "Wood":
                return woodCount;

        }
        return 0;
    }

    //resource is presented as a string, value can be a positive or negative int, will subtract from value (spending resources) or add from value (gathering)
    public void editResource(string resource, int value)
    {
        switch (resource)
        {
            case "Metal":
                metalCount += value;
                break;

            case "Rock":
                rockCount += value;
                break;

            case "Wood":
                woodCount += value;
                break;

        }

    }
    // sets displayed number of owned resources after adding number obtained from harvesting to current owned number
    public void setText(string resource)
    {
        switch (resource)
        {
            case "Metal":
                metalText.text = metal + metalCount;
                break;

            case "Rock":
                rockText.text = rock + rockCount;
                break;

            case "Wood":
                woodText.text = wood + woodCount;
                break;

        }
    }
}
