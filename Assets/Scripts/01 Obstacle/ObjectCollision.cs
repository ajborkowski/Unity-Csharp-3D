using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    // Start & Update not needed here..

    // OnCollisionEnter : built-in Unity method that interacts with object colliders
    private void OnCollisionEnter(Collision other) 
    {
        //Debug.Log("hit " + other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
        }
        
    }
}
