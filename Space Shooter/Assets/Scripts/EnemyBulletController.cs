using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 3f;

    public Transform playerTransform;

    public Rigidbody2D rb;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        direction = (playerTransform.position - transform.position).normalized;
        //rb.velocity = (playerTransform.position - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.playerController.HittedByBullet();
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
         
    }
}
