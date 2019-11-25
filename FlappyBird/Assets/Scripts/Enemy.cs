using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public Rigidbody2D rb;
    public float speed = -15;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfBehindBorder();
    }

    void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        if (colliderInfo.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
        else if (colliderInfo.gameObject.name == "Bullet(Clone)")
        {
            Destroy(gameObject);
            Destroy(colliderInfo.gameObject);
        }
        
    }

    void DestroyIfBehindBorder()
    {
        if(gameObject.transform.position.x < -10)
        {
            Destroy(gameObject);
            Debug.Log("Enemy destroyed");
        }
    }

}
