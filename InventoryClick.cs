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
/// Summary:Handles the player clicking buttons inside the inventory and finds where they clicked
/// </summary>
public class InventoryClick : MonoBehaviour {

    public Button inventoryButton;
    public Canvas inventoryOverlay;
    private GameObject player;
    private PlayerState playerStateScript;
    private bool inventoryOpen = false;

    void Start()
    {
        // Grab the player's controls
        player = GameObject.FindGameObjectWithTag("Player");
        playerStateScript = player.GetComponent<PlayerState>();

        // Add a listener onto the inventory button
        Button btn = inventoryButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    /*
     * This function handles the on click event of the inventory button. It will bring
     * up the inventory overlay and disable the player's controls
     */ 
    void TaskOnClick()
    {
        if (!inventoryOpen)
        {
            inventoryOverlay.enabled = true;
            playerStateScript.controlPlayer(false);
            inventoryOpen = true;
        }
        else
        {
            inventoryOverlay.enabled = false;
            playerStateScript.controlPlayer(true);
            inventoryOpen = false;
        }
        
    }
}
