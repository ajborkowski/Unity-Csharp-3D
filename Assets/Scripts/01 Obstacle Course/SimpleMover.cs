using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    [SerializeField] float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        PrintControlsToConsole();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float yValue = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(xValue, 0, yValue);
         /*
            Input.GetAxis() is an "old" way of getting input
            This returns a value between 0 and 1 and has assigned buttons
            in Project Settings > Input

            Time.deltaTime : Tells us how long each frame took
            Using this, we can normalize speed for fast & slow computers..

                                             Slow PC | Fast PC
                   FPS          |                10  | 100
            Duration (deltaTime)|               0.1s | 0.01s
            Distance Per Second | 1 x 10 x (0.1) = 1 | 1 x 100 x (0.01) = 1
        */
    }

    void PrintControlsToConsole()
    {
        Debug.Log("Basic WASD controls dummy!");
    }
}
