using UnityEngine;
using UnityEngine.SceneManagement;

public class BoostCollision : MonoBehaviour
{

    // FOUND BUG: if crashing THEN hitting finish, you go to next level (could be a feature though)

    // Params
    [SerializeField] float timeoutDelay = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    // Cache
    AudioSource sfx;

    // State
    bool isTransitioning = false;

    private void Start() 
    {
        sfx = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        // If we are in a transition state, leave this method
        if(isTransitioning){return;}

        switch(other.gameObject.tag)
        {
            case "Friendly":
                //Debug.Log("You hit a friendly.");
                break;
            case "Finish":
                //Debug.Log("You made it to finish.");
                HitGoal();
                break;
            default:
                //Debug.Log("Huh? What? You crashed.");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true; // gets reset to default state on level reload ***
        sfx.Stop(); // to prevent looping thrust audio
        sfx.PlayOneShot(crashSound);
        crashParticles.Play();
        GetComponent<RocketMovement>().enabled = false;
        Invoke("ReloadLevel", timeoutDelay);
    }

    void HitGoal()
    {
        isTransitioning = true;
        sfx.Stop(); // to prevent looping thrust audio
        sfx.PlayOneShot(successSound);
        successParticles.Play();
        GetComponent<RocketMovement>().enabled = false; // optional (could let player move and crash after success)
        Invoke("LoadNextLevel", timeoutDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        //GetComponent<RocketMovement>().enabled = true; // gets reset anyway
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
