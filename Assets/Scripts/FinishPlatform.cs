using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPlatform : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player enters the trigger area
        if (collision.CompareTag("Player"))  // Assuming the player has the "Player" tag
        {
            // Call the GoToMainMenu method in the GameManager
            SceneManager.LoadScene("Menu");
        }
    }
}
