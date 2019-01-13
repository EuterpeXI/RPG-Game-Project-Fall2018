using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Zachary Shaw
/// Amelia Chin
/// Waldo Lane
/// Nolan Mushtuk
/// Nicholas Brunnenkant
/// Date:December 14 2018
/// Summary:This just allows the player to restart the game if they have died
/// </summary>
public class RestartGame : MonoBehaviour {

    public Canvas gameOverScreen;

    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

	// If the R key was pressed, restart game
	void Update () {
        if (gameOverScreen.enabled && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
