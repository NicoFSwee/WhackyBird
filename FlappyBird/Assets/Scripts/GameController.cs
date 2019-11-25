using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int playerPoints;
    public bool winCondition;
    bool showEndgame = false;
    public Text pointsText;
    public GameObject obstacle;
    public Player player;
    public Enemy enemy;
    public GameObject levelComplete;
    public GameObject destroyableCrate;
    public GameObject points;
    bool startedSpawningEnemies;
    List<GameObject> obstacleList = new List<GameObject>();
    List<GameObject> pointList = new List<GameObject>();
    int numberOfObstacklesSpawned = 0;

    void Awake()
    {
        SpawnPlayer();
        levelComplete.SetActive(false);
    }

    private void SpawnPlayer()
    {
        player = Instantiate(player, new Vector3(-3f, 0f, 0f), Quaternion.identity);
    }

    // Start is called before the first frame updatew
    void Start()
    {
        playerPoints = 0;
        Invoke("CreateObstacle1", 1);
        InvokeRepeating("SpawnEnemy", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
        winCondition = CheckForWincondition();

        if(winCondition)
        {
            ShowGameWon();
        }
    }

    private void ShowGameWon()
    {
        if(!showEndgame)
        {
            levelComplete.SetActive(true);
            showEndgame = true;
            player.GetComponent<Collider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    private bool CheckForWincondition()
    {
        return playerPoints >= 20;
    }

    void FixedUpdate()
    {
        if (player.isAlive && !showEndgame)
        {
            Vector3 endOfMap = new Vector3(-10, 0, 0);

            foreach (GameObject go in obstacleList)
            {
                if (go != null)
                {
                    go.transform.Translate(Vector3.left * 2f * Time.deltaTime);
                }
            }

            for (int i = 0; i < pointList.Count; i++)
            {
                if (pointList[i] != null)
                {
                    pointList[i].transform.Translate(Vector3.left * 2f * Time.deltaTime);
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
    }

    public void CreateObstacle1()
    {
        int rnd = Random.Range(-3, 5);
        float nextRnd = rnd - 1;
        int rndSpawndestroyableCrate = Random.Range(0, 5);
        int spawnNoDestrCr = 5;

        if(!winCondition)
        {
            if (player.isAlive && obstacleList.Count < 500)
            {
                float y = -6;
                if (rndSpawndestroyableCrate % 2 == 0)
                {
                    while (y < 7)
                    {
                        if (y != nextRnd && y != rnd)
                        {
                            obstacleList.Add(Instantiate(obstacle, new Vector2(10, y), Quaternion.identity));
                        }
                        else if (y == nextRnd)
                        {
                            float tmp = (rnd - nextRnd) / 2;
                            pointList.Add(Instantiate(points, new Vector2(10, y + tmp), Quaternion.identity));
                            if (numberOfObstacklesSpawned >= spawnNoDestrCr)
                            {
                                obstacleList.Add(Instantiate(destroyableCrate, new Vector2(10, y), Quaternion.identity));
                                obstacleList.Add(Instantiate(destroyableCrate, new Vector2(10, y + 1), Quaternion.identity));
                            }
                        }
                        y = y + 1;
                    }
                }
                else
                {
                    while (y < 7)
                    {
                        if (y != nextRnd && y != rnd)
                        {
                            obstacleList.Add(Instantiate(obstacle, new Vector2(10, y), Quaternion.identity));
                        }
                        else if (y == nextRnd)
                        {
                            float tmp = (rnd - nextRnd) / 2;
                            pointList.Add(Instantiate(points, new Vector2(10, y + tmp), Quaternion.identity));
                        }

                        y = y + 1;
                    }
                }
            }
            numberOfObstacklesSpawned++;
        }

        int nextObstacle = Random.Range(1, 3);

        Invoke("CreateObstacle" + nextObstacle.ToString(), 3);
    }

    public void CreateObstacle2()
    {
        int rnd = Random.Range(-3, 5);
        float nextRnd = rnd - 1;
        int rndSpawndestroyableCrate = Random.Range(0, 5);
        int spawnNoDestrCr = 5;

        if(!winCondition)
        {
            if (player.isAlive && obstacleList.Count < 500)
            {
                float y = -6;
                int i = 0;
                if (rndSpawndestroyableCrate % 2 == 0)
                {
                    while (y < 7)
                    {
                        if (y != nextRnd && y != rnd)
                        {
                            obstacleList.Add(Instantiate(obstacle, new Vector2(10 - i, y), Quaternion.identity));
                        }
                        else if (y == nextRnd)
                        {
                            float tmp = (rnd - nextRnd) / 2;
                            pointList.Add(Instantiate(points, new Vector2(10 - i + 0.5f, y + tmp), Quaternion.identity));
                            if (numberOfObstacklesSpawned >= spawnNoDestrCr)
                            {
                                obstacleList.Add(Instantiate(destroyableCrate, new Vector2(10 - i, y), Quaternion.identity));
                                obstacleList.Add(Instantiate(destroyableCrate, new Vector2(10 - i + 1, y + 1), Quaternion.identity));
                            }
                        }
                        y = y + 1;
                        i--;
                    }
                }
                else
                {
                    while (y < 7)
                    {
                        if (y != nextRnd && y != rnd)
                        {
                            obstacleList.Add(Instantiate(obstacle, new Vector2(10 - i, y), Quaternion.identity));
                        }
                        else if (y == nextRnd)
                        {
                            float tmp = (rnd - nextRnd) / 2;
                            pointList.Add(Instantiate(points, new Vector2(10 - i + 0.5f, y + tmp), Quaternion.identity));
                        }
                        i--;
                        y = y + 1;
                    }
                }
            }
            numberOfObstacklesSpawned++;
        }
       

        int nextObstacle = Random.Range(1, 4);
        if(nextObstacle == 2)
        {
            Invoke("CreateObstacle" + nextObstacle.ToString(), 3);
        }
        else
        {
            Invoke("CreateObstacle" + nextObstacle.ToString(), 8);
        }
        
    }

    public void CreateObstacle3()
    {
        int rnd = Random.Range(-3, 5);
        float nextRnd = rnd - 1;
        int obstacleLength = 10;

        if(!winCondition)
        {
            if (player.isAlive && obstacleList.Count < 500)
            {
                float y = 0;
                int i = 0;

                while (y < obstacleLength)
                {
                    obstacleList.Add(Instantiate(obstacle, new Vector2(10 + i, 0), Quaternion.identity));

                    y = y + 1;
                    i++;
                }
            }
            numberOfObstacklesSpawned++;
        }

        int nextObstacle = Random.Range(1, 3);
        Invoke("CreateObstacle" + nextObstacle.ToString(), 8);
    }

    void UpdatePoints()
    {
        pointsText.text = "Punkte: " + playerPoints.ToString();
    }

    void SpawnEnemy()
    {
        startedSpawningEnemies = playerPoints >= 5;
        if(startedSpawningEnemies && player.isAlive && !showEndgame)
        {
            int rnd = Random.Range(-4, 5);
            Instantiate(enemy, new Vector3(enemy.transform.position.x, rnd, 0), Quaternion.identity);
        }
    }
    void NeuLaden()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenue()
    {
        SceneManager.LoadScene("MainMenue");
    }
}
