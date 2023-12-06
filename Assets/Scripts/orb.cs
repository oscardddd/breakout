using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class orb : MonoBehaviour
    
{
    public float miny = -5f;
    public float maxspeed = 5f;
    int count;
    Rigidbody2D rb;
    int score = 0;
    int lives = 3;
    public TextMeshProUGUI scoretext;
    public GameObject[] hearts;
    public GameObject gameoverpanel;
    public GameObject winpanel;
    public AudioClip scoresound;
    private AudioSource ad;
    
    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        count = FindObjectOfType<generater>().transform.childCount + 1;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y < miny)
        {
           
            if (lives <= 0)
            {
                hearts[lives].SetActive(false);
                end();
            }
            else
            {
                transform.position = new Vector3(0,-1.5f,0);
                rb.velocity = Vector3.zero;
                
                hearts[lives].SetActive(false);
                lives -= 1;
            }

        }
        if(rb.velocity.magnitude > maxspeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
        
    {
       
        if (collision.gameObject.CompareTag("Brick"))
        {
            //Debug.Log("aha");
            Destroy(collision.gameObject);
            score += 1;
            ad.PlayOneShot(scoresound, 1.0f);
            scoretext.text = score.ToString("000");
            count -= 1;
            if (count <= 0)

            {
                winpanel.SetActive(true);
                Time.timeScale = 0;
                Destroy(gameObject);

            }

        }
        else if (collision.gameObject.CompareTag("mBrick"))
        {
            //Debug.Log("aha");
            Destroy(collision.gameObject);
            score += 5;
            ad.PlayOneShot(scoresound, 1.0f);
            scoretext.text = score.ToString("000");
            count -= 1;

            if (count <= 0)

            {
                winpanel.SetActive(true);
                Time.timeScale = 0;
                Destroy(gameObject);

            }

        }



    }
    private void end()
    {
        gameoverpanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}

