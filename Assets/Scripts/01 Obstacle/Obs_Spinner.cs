using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Spinner : MonoBehaviour
{
    [SerializeField] float spinSpeed = 1;

    void Start(){}

    void Update()
    {
        transform.Rotate(0, spinSpeed, 0);
    }
}
