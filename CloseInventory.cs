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
/// Summary:this actually just closes the inventory screen
/// </summary>
public class CloseInventory : MonoBehaviour {
    public Button CloseButton;
    public Canvas inventoryOverlay;
    private GameObject player;
    private PlayerState playerStateScript;

    void Start()
    {
        // Grab the player's controls
        player = GameObject.FindGameObjectWithTag("Player");
        playerStateScript = player.GetComponent<PlayerState>();

        // Add a listener onto the inventory button
        Button btn = CloseButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    /*
     * Upon each frame, check to see if user had pressed the esc key. If they did, check
     * if the inventory overlay is enabled, and if that is enabled... disable it.
     */ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryOverlay.enabled)
            {
                inventoryOverlay.enabled = false;
                playerStateScript.controlPlayer(true);
            }
        }
    }

    /*
     * This function handles the on click event of the inventory button. It will close
     * the inventory overlay and enable the player's controls
     */
    void TaskOnClick()
    {
        inventoryOverlay.enabled = false;
        playerStateScript.controlPlayer(true);
    }
}
