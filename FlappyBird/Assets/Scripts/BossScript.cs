using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject boss;
    public Transform firepoint;
    public Animator anim;
    public GameObject bullet;
    public float speed;
    Player player;
    public float lifePoints;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        HandleMovement();
        InvokeRepeating("Shoot", 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        if(player.isAlive)
        {
            anim.SetBool("IsShooting", true);
            Instantiate(bullet, firepoint);
            boss.GetComponent<AudioSource>().Play();
            Invoke("CancelAnim", 1);
        }
    }

    void CancelAnim()
    {
        anim.SetBool("IsShooting", false);
    }

    void HandleMovement()
    {
        int rnd = Random.Range(0, 2);

        if(rnd == 0)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        if(boss.transform.position.y <= 5)
        {
            //boss.transform.Translate(0f, 10f * speed * Time.deltaTime, 0f);
            boss.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f * speed * Time.deltaTime);
        }

        Invoke("HandleMovement", 0.5f);
    }

    void MoveDown()
    {
        if (boss.transform.position.y >= -7)
        {
            //boss.transform.Translate(0f, -10f * speed * Time.deltaTime, 0f);
            boss.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -10f * speed * Time.deltaTime);
        }

        Invoke("HandleMovement", 0.5f);
    }
}
