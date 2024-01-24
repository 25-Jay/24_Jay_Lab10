using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if (transform.position.y >= 10)
        {
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }

        else if (transform.position.y <= 2)
        {
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);
        }

        scoreText.text = "Score: " + score;



    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
     public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {

            score += 10;
        }
    }
    
}
