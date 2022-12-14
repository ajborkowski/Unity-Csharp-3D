using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    
    void Start()
    {
        // Setting startPos to world location
        startPos = transform.position;
    }

    
    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
        transform.position = startPos + offset;
    }
}
