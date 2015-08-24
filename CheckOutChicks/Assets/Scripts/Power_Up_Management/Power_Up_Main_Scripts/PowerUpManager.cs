﻿//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUp[] availablePowerUps;
    //public static string[] availablePowerUpsList;
    private int currentMapPowerUps;
    private int lastPowerUp;
    private int maxMapPowerUps = 2;
    private float maxSpawnDelay = 2;
    private float minSpawnDelay = 1;
    private int nextPowerUp;
    private bool nextSpawnPointCheck;

    [SerializeField]
    private Sprite[] powerUpIcons;

    private GameObject[] powerUpSpawnPoints;
    private float powerUpSpawnTimer;

    public PowerUp[] AvailablePowerUp
    {
        get { return availablePowerUps; }
        set { availablePowerUps = value; }
    }

    public int CurrentMapPowerUps
    {
        get { return currentMapPowerUps; }
        set { currentMapPowerUps = value; }
    }

    public int MaxMapPowerUps
    {
        get { return maxMapPowerUps; }
        set { maxMapPowerUps = value; }
    }

    public Sprite[] PowerUpIcons
    {
        get { return powerUpIcons; }
    }

    private void Awake()
    {
        FindPowerUpSpawnPoints();
        MaxMapPowerUps = powerUpSpawnPoints.Length;
        SetAvailablePowerUps();
    }

    private void FindPowerUpSpawnPoints()
    {
        powerUpSpawnPoints = GameObject.FindGameObjectsWithTag("Power_Up_Spawn_Point");

        for (int i = 0; i < powerUpSpawnPoints.Length; i++)
        {
            powerUpSpawnPoints[i].SetActive(false);
        }
    }

    private void SetAvailablePowerUps()
    {
        availablePowerUps = new PowerUp[5];
        //availablePowerUpsList = new string[5];

        availablePowerUps[0] = new StickyPuddle();
        //availablePowerUpsList[0] = "Sticky_Puddle";

        availablePowerUps[1] = new ConfuseOther();
        //availablePowerUpsList[1] = "Confuse_Other";

        availablePowerUps[2] = new TurboBoost();
        //availablePowerUpsList[2] = "Turbo";

        availablePowerUps[3] = new SlipperyWhenWet();
        //availablePowerUpsList[3] = "Slippery_When_Wet";

        availablePowerUps[4] = new PointBoost();
        //availablePowerUpsList[4] = "Point_Boost";
    }

    private void SpawnPowerUp()
    {
        if (currentMapPowerUps + 1 <= MaxMapPowerUps)
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

    private void Update()
    {
        SpawnPowerUp();
    }

    //Sicherheitskopie
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