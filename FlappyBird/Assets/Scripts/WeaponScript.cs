using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Text pointsText;
    public GameObject weaponAquiredMsg;
    GameController gc;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        weaponAquiredMsg = GameObject.Find("WeaponAquiredText");
    }
    void Update()
    {
        if(gc != null)
        {
            if (gc.playerPoints == 5)
            {
                weaponAquiredMsg.GetComponent<Text>().text = "5 Points: You got a weapon";
                Invoke("CancelText", 5);
            }
            if (Input.GetButtonDown("Fire1") && gc.playerPoints >= 5)
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void CancelText()
    {
        weaponAquiredMsg.GetComponent<Text>().text = "";
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
