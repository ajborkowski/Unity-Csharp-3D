using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    // *** FOUND BUG: particles keep playing after collision

    /*
        Standardizing member variables in this way is a good idea!

        Parameters - for tuning, typically in the editor
        Cache - e.g. references for readibility or speed
        State - private instance variables
    */

    // Parameters
    [SerializeField] float mainThrust = 1000f; // drag applied to RB
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;

    // Cache
    Rigidbody rb;
    AudioSource sfx;

    // State
    // bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed space");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!sfx.isPlaying)
            {
                sfx.PlayOneShot(mainEngine);
            }
            if(!mainThrustParticles.isPlaying)
            {
                mainThrustParticles.Play();
            }
        }
        else
        {
            sfx.Stop();
            mainThrustParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
            if (!rightThrustParticles.isPlaying)
            {
                rightThrustParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
            if (!leftThrustParticles.isPlaying)
            {
                leftThrustParticles.Play();
            }
        }
        else
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation to manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // re-enable Rigidbody constraints
    }
}
