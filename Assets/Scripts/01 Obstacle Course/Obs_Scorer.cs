using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Scorer : MonoBehaviour
{
    int score = 0;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Hit")
        {
            score++;
            Debug.Log("You hit something " + score + " times..");
        }
    }
}
