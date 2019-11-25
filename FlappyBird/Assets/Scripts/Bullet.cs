using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    public float damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "DestroyableCrate(Clone)")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Crate(Clone)")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Enemy(Clone)")
        {
            GameController gc = FindObjectOfType<GameController>();
            gc.playerPoints += 3;
            Debug.Log("Added Point!");
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name == "Boss(Clone)")
        {
            BossScript boss = FindObjectOfType<BossScript>();
            boss.lifePoints -= damage;
            Debug.Log(boss.lifePoints.ToString());
            Destroy(gameObject);
            if(boss.lifePoints <= 0)
            {
                Destroy(col.gameObject);
            }
        }
    }
}
