using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingbrick : MonoBehaviour
{
    public float speed = 6f;
    bool direction = true;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 6)
        {
            direction = false;
        }
        else if (transform.position.x < -6)
        {
            direction = true;
        }
        // rightward
        if (direction)
        {
            x = transform.position.x + 0.005f; 
            transform.position = new Vector3(x, -1, 0);
        }
        else
        {
            x = transform.position.x - 0.005f;
            transform.position = new Vector3(x, -1, 0);
        }
    }
}
