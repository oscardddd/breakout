using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class generater : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 offset;
    private float xspan = 2f;
    private float yspan = 1f;
    public GameObject brickprefab;
    public GameObject mbrickfab;
    public float starty;
    // Start is called before the first frame update
    private void Awake()
    {
        float lowy = starty - 1.5f;
        //var mbrick = Instantiate(mbrickfab, transform);
        //Vector3 mp = new Vector3(0, lowy, 0);
        //mbrick.transform.position= mp;
        
        for (int i= 0; i < size.x; i++)
        {
            for (int j =0;j < size.y; j++)
            {
                var brick = Instantiate(brickprefab, transform);
                Vector3 p = new Vector3(i* xspan- 5f, j*yspan+starty, 0);
                brick.transform.position = transform.position + p;
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
