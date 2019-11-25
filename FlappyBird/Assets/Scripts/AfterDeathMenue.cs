using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterDeathMenue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menueUI;
    Player player;
    public Text punkte;
    

    void Start()
    {
        player = FindObjectOfType<Player>();
        menueUI.SetActive(false);
        player.GetComponent<GameObject>();
    }

    void Update()
    {
        if(!player.isAlive)
        {
            menueUI.SetActive(true);
            
            player.GetComponent<AudioSource>().Stop();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        menueUI.SetActive(false);
    }

    public void LoadMenue()
    {
        SceneManager.LoadScene("MainMenue");
    }
}
