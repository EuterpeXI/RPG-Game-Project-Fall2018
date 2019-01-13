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
/// Summary:This is the player state script to check on how the player is doing wether ot not we have died and what state the player is in within the world at a given time
/// </summary>
public class PlayerState : MonoBehaviour {

    public float batteryDrainRate = 0.005f;  // Battery's drain rate in float
    public float maxBatteryLife; // Max battery health float value
    public Image playerBattery; // UI representation of the battery
    public float playerDamage;
    public Canvas gameOverScreen;

    private bool canControl = true; // Boolean value for controls of the player
    private bool timeSpent = false; // Boolean value to check if time was spent during gameplay
    private float currentBatteryLife; // Current battery life float value
    private PlayerController controlScript; // Reference PlayerController script
    private GameObject player;
    private Animator m_Animator;
    //basic start func
    private void Start()
    {
        maxBatteryLife = 100;
        currentBatteryLife = maxBatteryLife;
        controlScript = this.GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
        m_Animator = player.GetComponent<Animator>();
    }
    //basic update
    private void Update()
    {
        
        if (!timeSpent)
        {
            StartCoroutine(waitNSeconds(1));
        }

        // If player is sprinting, apply the drain rate
        if (controlScript.get_sprint())
        {
            drainRate(0.006f);

            // Comment out the drainRate above and uncomment the one below to test out GameOver Overlay
            //drainRate(0.6f); 
        }

        // If player is harvesting, drain because it takes energy
        if (m_Animator.GetBool("isHarvesting"))
        {
            drainRate(0.008f);
        }

        if (playerBattery.fillAmount <= 0)
        {
            gameOverScreen.enabled = true;
            this.controlPlayer(false);
        }
    }

    /*
     * This function acts as the gatekeeper of the controls. 
     * It will return a boolean value. True = if player is allowed to control. 
     * False = if player is not allowed to control.
     */ 
    public bool canControlPlayer()
    {
        return canControl;
    }

    /*
     * This function sets the boolean values of the controls.
     */ 
    public void controlPlayer(bool control)
    {
        canControl = control;
    }

    /*
     * This helper function returns the percentage of the battery by taking
     * its current dividing by its max.
     */ 
    public float getBatteryPercentage()
    {
        return currentBatteryLife / maxBatteryLife;
    }

    /*
     * This function returns the current set battery drain rate.
     */ 
    public float getBatteryDrainRate()
    {
        return this.batteryDrainRate;
    }

    /*
     * This function takes in a float value for the new drain rate and sets that 
     * as the new battery rate.
     */ 
    public void setBatteryDrainRate(float newRate)
    {
        this.batteryDrainRate = newRate;
    }

    /*
     * This function sets given new max battery life to be the currentBatteryLife and maxBatteryLife.
     * Basically, when the player gets an increased battery capacity, the battery will become full.
     */ 
    public void setMaxBatteryLife(float newMax)
    {
        this.currentBatteryLife = newMax;
        this.maxBatteryLife = newMax;
        playerBattery.fillAmount += 1; // Reset the battery visual representation to be full
    }

    /*
     * This function handles the given drain rate when the player is sprinting.
     * Note: The given newRate should be faster than the current drain rate.
     */ 
    private void drainRate(float newRate)
    {
        currentBatteryLife -= newRate/maxBatteryLife;
        playerBattery.fillAmount -= newRate/maxBatteryLife;
    }

    /*
     * This function handles the cases where the player gets an item that "heals" the battery
     * life.
     */ 
    public void addLife(float amount)
    {
        this.currentBatteryLife += amount;
        playerBattery.fillAmount += amount;
    }

    /*
     * This function returns the player's damage
     */ 
    public float getPlayerDamage()
    {
        return this.playerDamage;
    }

    /*
     * Setup for the coroutine. Battery life will continue to decrease at a set rate every second to 
     * represent the battery loss as the player is "alive."
     */ 
    IEnumerator waitNSeconds(float n)
    {
        timeSpent = true;
        currentBatteryLife -= batteryDrainRate/maxBatteryLife;
        playerBattery.fillAmount -= batteryDrainRate/maxBatteryLife;

        yield return new WaitForSeconds(n);
        timeSpent = false;
    }

    /*
     * This eventhandler handles when the player gets attacked by the enemy.
     */ 
    void OnCollisionEnter(Collision collision)
    {
        // If the player was hit by an enemy
        if (collision.gameObject.tag == "Enemy")
        {
            // Drain by some rate
            drainRate(0.01f);
        }
    }

    /*
     * This eventhandler handles when the player is in the water.
     */
    private void OnCollisionStay(Collision collision)
    {
        //If the player is in the water
        if (collision.gameObject.tag == "Water")
        {
            // Drain by some rate
            drainRate(0.4f);
        }
    }
}
