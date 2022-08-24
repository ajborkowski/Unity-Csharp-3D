using UnityEngine;
using UnityEngine.SceneManagement;

public class BoostCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You hit a friendly.");
                break;
            case "Finish":
                Debug.Log("You made it to finish.");
                break;
            default:
                Debug.Log("Huh? What? You crashed.");
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        //SceneManager.LoadScene(0);
        // !!! This is how you'd reload the current level
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
}
