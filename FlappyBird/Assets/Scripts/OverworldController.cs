using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldController : MonoBehaviour
{
    public PlayerOverworld player;
    public Animator anim;
    Vector3 waypoint1 = new Vector3(0.867f, -0.685f, -1f);
    Vector3 waypoint2 = new Vector3(-1.69f, -0.77f, -1f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            GoToNextWaypoint(waypoint2);
        }
    }

    private void GoToNextWaypoint(Vector3 waypoint2)
    {
        for(float i = player.transform.position.x; i <= waypoint2.x; i += .1f)
        {
            player.transform.Translate(new Vector3(waypoint2.x, 0f, 0f));
            Debug.Log(player.transform.position.x.ToString());
        }
        
    }

    void CancelAnim()
    {
        anim.SetBool("IsTriggered", false); 
    }

}
