using UnityEngine;
using UnityEngine.SceneManagement;

public class BoostCollision : MonoBehaviour
{
    [SerializeField] float timeoutDelay = 1f;

    private void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                //Debug.Log("You hit a friendly.");
                break;
            case "Finish":
                //Debug.Log("You made it to finish.");
                LoadNextLevel();
                break;
            default:
                //Debug.Log("Huh? What? You crashed.");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        GetComponent<RocketMovement>().enabled = false;
        Invoke("ReloadLevel", timeoutDelay);
    }

    void HitGoal()
    {
        GetComponent<RocketMovement>().enabled = false; // optional
        Invoke("LoadNextLevel", timeoutDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        GetComponent<RocketMovement>().enabled = true;
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    
}
