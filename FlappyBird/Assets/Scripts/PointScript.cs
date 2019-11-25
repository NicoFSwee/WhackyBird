using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    GameController gc;
    bool isCollided = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && !isCollided)
        {
            gc.playerPoints += 10;
            isCollided = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
