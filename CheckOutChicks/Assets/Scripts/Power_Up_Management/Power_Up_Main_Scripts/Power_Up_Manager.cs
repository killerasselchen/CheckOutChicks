using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Power_Up_Manager : MonoBehaviour {

    private int maxMapPowerUps;
    private int currentMapPowerUps;
    private int nextPowerUp;
    private int lastPowerUp;
    private bool nextSpawnPointCheck;
    private float powerUpSpawnTimer;
    private float minSpawnDelay = 1;
    private float maxSpawnDelay = 2;

    private GameObject[] powerUpSpawnPoints;

    public static Power_Up[] availablePowerUps;
    public static string[] availablePowerUpsList;

    public int MaxMapPowerUps
    {
        get { return maxMapPowerUps;}
        set { maxMapPowerUps = value;}
    }

    public int CurrentMapPowerUps
    {
        get { return currentMapPowerUps;}
        set { currentMapPowerUps = value; }
    }

    public Power_Up[] AvailablePowerUp
    {
        get { return availablePowerUps;}
        set { availablePowerUps = value;}
    }

    void Awake()
    {
        FindPowerUpSpawnPoints();
        MaxMapPowerUps = powerUpSpawnPoints.Length / 2;
        SetAvailablePowerUps();
    }

    void Update()
    {
        SpawnPowerUp();
    }

	void FindPowerUpSpawnPoints()
    {
        powerUpSpawnPoints = GameObject.FindGameObjectsWithTag("Power_Up_Spawn_Point");

        for (int i = 0; i < powerUpSpawnPoints.Length; i++)
        {
            powerUpSpawnPoints[i].SetActive(false);
        }
    }

    void SpawnPowerUp()
    {
        //if(currentMapPowerUps <= maxMapPowerUps && powerUpSpawnTimer <= 0)
        //{
        //    nextPowerUp = Random.Range(0,powerUpSpawnPoints.Length);
        //    if(nextPowerUp != lastPowerUp)
        //    {
                
        //    }
        //    powerUpSpawnTimer -= 1.0f * Time.deltaTime;
        //}
        if (currentMapPowerUps <= maxMapPowerUps)
        {
            if (powerUpSpawnTimer <= 0)
            {
                nextSpawnPointCheck = true;
                while (nextSpawnPointCheck == true)
                {
                    nextPowerUp = Random.Range(0, powerUpSpawnPoints.Length);

                    if (!powerUpSpawnPoints[nextPowerUp].activeInHierarchy)
                    {
                        powerUpSpawnPoints[nextPowerUp].SetActive(true);
                        nextSpawnPointCheck = false;
                        currentMapPowerUps++;
                    }
                    powerUpSpawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
                }
            }
            powerUpSpawnTimer -= 1 * Time.deltaTime;
        }
    }

    void SetAvailablePowerUps()
    {
        availablePowerUps = new Power_Up[1];
        availablePowerUpsList = new string[1];

        //if(bool für jedes PowerUp)
        //Liste mit Items und die Liste der Namen füllen
        //AufListe umbauen, da es so vorab feststehen muß... zudem kann man per bool bei einer list jeder Item für sich activieren oder eben nicht
        availablePowerUps[0] = new Sticky_Puddle();
        availablePowerUpsList[0] = "Sticky_Puddle";

        //availablePowerUps[1] = new Confuse_Other();
        //availablePowerUpsList[1] = "Confuse_Other";

        //availablePowerUps[2] = new Turbo_Boost();
        //availablePowerUpsList[2] = "Turbo";
    } 

    //void SpawnNextItem()
    //{
    //    if (currentItems <= maxItems && products.Count > 0)
    //    {
    //        if (spawnTimer <= 0)
    //        {
    //            nextItem = Random.Range(0, products.Count);
    //            products[nextItem].SetActive(true);
    //            currentItems++;
    //            spawnTimer = Random.Range(0, 4);
    //        }
    //        spawnTimer -= 1.0f * Time.deltaTime;
    //    }

    //    else if (Products.Count == 0)
    //    {
    //        products = new List<GameObject>(productsBackUp);
    //    }
    //}
}
