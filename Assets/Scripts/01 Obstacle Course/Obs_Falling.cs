using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Falling : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Rigidbody rigidBody;
    [SerializeField] float waitTime = 5;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        meshRenderer.enabled = false;
    }

    void Update()
    {
        //Debug.Log(Time.time);
        if(Time.time >= waitTime)
        {
            meshRenderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }
}
