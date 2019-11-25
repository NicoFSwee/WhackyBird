using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameController : MonoBehaviour
{
    public BossScript boss;
    List<GameObject> obstacleList = new List<GameObject>();
    public Player player;
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player);
        Invoke("CreateObstacleToBoss", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 endOfMap = new Vector3(-10, 0, 0);

        foreach (GameObject go in obstacleList)
        {
            if (go != null)
            {
                go.transform.Translate(Vector3.left * 2f * Time.deltaTime);
            }
        }

        for (int i = 0; i < obstacleList.Count - 1; i = i + 6)
        {
            if (obstacleList[i] != null && obstacleList[i].transform.position.x < endOfMap.x)
            {
                Destroy(obstacleList[i]);
                obstacleList.RemoveAt(i);
            }
        }
    }

    void CreateObstacleToBoss()
    {
        int i = 0;

        if (obstacleList.Count < 500)
        {
            float y = -6;

            while (y < 7)
            {
                if (y != 0 && y != 1)
                {
                    obstacleList.Add(Instantiate(obstacle, new Vector2(10, y), Quaternion.identity));
                }
                y = y + 1;
            }
        }

        Invoke("CreateNextObstacle", 1);
    }

    void CreateNextObstacle()
    {
        if (obstacleList.Count < 500)
        {
            float y = -6;

            while (y < 7)
            {
                if (y != 0 && y != 1 && y != -1 && y != 2)
                {
                    obstacleList.Add(Instantiate(obstacle, new Vector2(10, y), Quaternion.identity));
                }
                y = y + 1;
            }
        }

        Invoke("CreateNextObstacle2", 1);
    }

    void CreateNextObstacle2()
    {
        if (obstacleList.Count < 500)
        {
            float y = -6;

            while (y < 7)
            {
                if (y != 0 && y != 1 && y != -1 && y != 2 && y != -2 && y != 3)
                {
                    obstacleList.Add(Instantiate(obstacle, new Vector2(10, y), Quaternion.identity));
                }
                y = y + 1;
            }
        }

        Invoke("SpawnBoss", 5);
    }

    void SpawnBoss()
    {
        Instantiate(boss);
    }
}
