using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.6f;

    public Transform playerTransform;

    public float fireRate = 1f;
    private float timeSinceLastAction = 0f;

    public GameObject bulletPrefab;
    public Transform enemyGunEnd;

    public GameObject explosionEffectPrefab;

    [SerializeField]
    private AudioClip _explosionClip;

    public BulletController bulletController;   



    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGameObject = GameObject.Find("Player");
        playerTransform = playerGameObject.transform;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y > -2)
        Shoot();

        if (transform.position.y < -5.5f)
        {
            GameManager.playerController.HittedByBullet();
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            bulletController.zebranePunkty++;
            Debug.Log(bulletController.zebranePunkty);
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(_explosionClip, transform.position);
        }

   

        if (collision.gameObject.tag == "Player")
        {
            GameManager.playerController.HittedByBullet();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(_explosionClip, transform.position);
        }

        }

        void Shoot()
    {
        timeSinceLastAction += Time.deltaTime;

        if (timeSinceLastAction >= fireRate)

        {
            Instantiate(bulletPrefab, enemyGunEnd.position, Quaternion.identity);
            timeSinceLastAction = 0;
        }
    }
}

