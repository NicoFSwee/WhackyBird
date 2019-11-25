using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public Player gc;
    Vector3 actualpos1;
    Vector3 actualpos2;
    Vector3 actualpos3;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gc.isAlive)
        {
            bg1.transform.Translate(Vector3.left * 1f * Time.deltaTime);
            bg2.transform.Translate(Vector3.left * 1f * Time.deltaTime);
            bg3.transform.Translate(Vector3.left * 1f * Time.deltaTime);
            actualpos1 = bg1.transform.position;
            actualpos2 = bg1.transform.position;
            actualpos3 = bg1.transform.position;

            if (bg2.transform.position.x < -32.79)
            {
                bg2.transform.position = new Vector3(bg1.transform.position.x + 32.79f, bg1.transform.position.y, bg1.transform.position.z);
            }
            if (bg3.transform.position.x < -32.79)
            {
                bg3.transform.position = new Vector3(bg2.transform.position.x + 32.79f, bg2.transform.position.y, bg2.transform.position.z);
            }
            if (bg1.transform.position.x < -32.79)
            {
                bg1.transform.position = new Vector3(bg3.transform.position.x + 32.79f, bg3.transform.position.y, bg3.transform.position.z);
            }
        }


    }
}
