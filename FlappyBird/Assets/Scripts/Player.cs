using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D bird;
    public Animator animation;
    public bool isAlive;
    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        bird = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameHasEnded())
        {
            Fly(Input.GetAxis("Vertical"));
        } 
    }

    bool GameHasEnded()
    {
        if(gc != null)
        {
            return gc.winCondition;
        }
        return false;
    }

    public void PlaySound()
    {
        if (Input.GetKeyDown(KeyCode.W) && isAlive && !PauseMenue.gameIsPaused)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void Fly(float h)
    {
        if (isAlive)
        {
            bird.velocity = new Vector2(0.0f, 12.0f * h);
            PlaySound();
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        Debug.Log("Collision detected with: " + obj.gameObject.name.ToString());

        if (obj.gameObject.name == "Spielgrenze" && isAlive && !GameHasEnded())
        {
            animation.enabled = false;
            bird.GetComponent<Rigidbody2D>().Sleep();
            isAlive = false;
            AudioSource[] sources = gameObject.GetComponents<AudioSource>();
            sources[1].Play();
            bird.velocity = new Vector2(-5, 30);
            bird.rotation = -180;
        }
        else if (obj.gameObject.name == "Crate(Clone)" && isAlive && !GameHasEnded())
        {
            animation.enabled = false;
            bird.GetComponent<Rigidbody2D>().Sleep();
            isAlive = false;
            AudioSource[] sources = gameObject.GetComponents<AudioSource>();
            sources[1].Play();
            bird.velocity = new Vector2(-10, 10);
            bird.rotation = -180;
        }
    }

    void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Enemy")
        {
            animation.enabled = false;
            bird.GetComponent<Rigidbody2D>().Sleep();
            isAlive = false;
            AudioSource[] sources = gameObject.GetComponents<AudioSource>();
            sources[1].Play();
            bird.velocity = new Vector2(-5, 10);
            bird.rotation = -180;
        }
        else if (colliderInfo.gameObject.name == "EnemyBullet(Clone)")
        {
            animation.enabled = false;
            bird.GetComponent<Rigidbody2D>().Sleep();
            isAlive = false;
            AudioSource[] sources = gameObject.GetComponents<AudioSource>();
            sources[1].Play();
            bird.velocity = new Vector2(-5, 10);
            bird.rotation = -180;
        }
    }
}
