using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class LvlMenager : MonoBehaviour
{
    public TextMeshProUGUI hints;

    public PlayerController playerController;

    public BulletController bulletController;


    private void Start()
    {
        // Initially hide the "Press E" text
        hints.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // Check if the 'E' key is pressed
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        // Load the next scene
        // LoadNextLevel();
        //}

        // If the player presses 'E' and is colliding with an interactable object
        if (hints.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            // Perform some action (e.g., interacting with the object)
            Debug.Log("Interacted with the object!");

            // Optionally hide the text again after interaction
            hints.gameObject.SetActive(false);

        }

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collision is with a specific object (e.g., an NPC or interactable object)
        if (collider.gameObject.tag == "Player") 
        {
            // Show the "Press E" text
            hints.gameObject.SetActive(true);
        }

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
         
            {

                // Load the next scene
                LoadNextLevel();
                
            }
        }

 

        // Function to load the next scene
        void LoadNextLevel()
        {
            // Get the current scene's build index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Load the next scene based on the current index
            int nextSceneIndex = currentSceneIndex + 1;

            // Ensure the next scene exists (in case you are at the last scene)
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                // Load the next scene
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                // Optionally, loop back to the first scene or show a message
                Debug.Log("No more levels.");
                // SceneManager.LoadScene(0); // Uncomment to go back to the first level
            }
        }
    }
}