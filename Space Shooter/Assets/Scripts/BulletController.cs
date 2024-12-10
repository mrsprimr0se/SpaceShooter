using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BulletController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;

    public float destroyYValue = 6f;

    public int points = 10;

    public BulletController bulletController;

    //public AudioSource audioSource;

    //public AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AudioSource>().playOnAwake = false;
        //GetComponent<AudioSource>().clip = audioClip;

        rb = GetComponent<Rigidbody2D>();
       
        //rb.velocity = Vector2.up * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        DestroyAfterLeftScreen();
    }

    void DestroyAfterLeftScreen()
    {
        if (transform.position.y > destroyYValue)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

            if (collision.gameObject.tag == "Enemy")
            {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                 scoreManager.AddScore(points);

            //GetComponent<AudioSource>().Play();

            Destroy(gameObject);
             }

            if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
            
                

      //if (collision.gameObject.tag == "Enemy")

        {
            //Destroy(gameObject);
        }
        

      //if (collision.gameObject.tag == "EnemyBullet")

        {
            //Destroy(gameObject);
        }
        
        
    }



}