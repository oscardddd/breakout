using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Paddle : MonoBehaviour
{
    public TextMeshProUGUI speedtext;
    public float speed = 14f;
    public float bound = 8f;
    float xmove;
    // Start is called before the first frame update
    void Start()
    {
        speedtext.text = speed.ToString("00");

    }

    // Update is called once per frame
    void Update()
    {
        xmove = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow) && speed <= 28)
        {
            speed += 2;
            speedtext.text = speed.ToString("00");

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && speed >= 12)
        {
            speed -= 2;
            speedtext.text = speed.ToString("00");
        }

        if ((xmove<0 && transform.position.x >-bound ) || (xmove>0 && transform.position.x <bound))
        {
            transform.position += Vector3.right * xmove * speed * Time.deltaTime;
        }
        
    }
}
