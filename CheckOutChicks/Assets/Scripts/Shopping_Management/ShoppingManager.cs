//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShoppingManager : MonoBehaviour 
{
    private List<GameObject> products;
    private List<GameObject> productsBackUp;
    private List<GameObject> activeProducts;
    public static int currentItems = 0;
    private int maxItems = 2;
    private int nextItem;
    private float spawnTimer = 1;

    // Point System
    private float maxPoints;

    public delegate void ItemEvent(Item item);
    public ItemEvent OnCreateItem;
    public ItemEvent OnDeactivateItem;

    void Awake()
    {
        maxPoints = 30;
        //bonusTime = 10;
        //minPoints = maxPoints / (bonusTime + 1);
        FindAvailableProducts();
    }

    void Update()
    {
        SearchActivProducts();
        SpawnNextItem();
    }

    public List<GameObject> Products
    {
        get { return products;}
        set { products = value;}
    }

    public List<GameObject> ActiveProducts
    {
        get { return activeProducts; }
        set { activeProducts = value; }
    }

    public int MaxItems
    {
        get { return maxItems;}
        set { maxItems = value; }
    }

    void FindAvailableProducts()
    {
        products = new List<GameObject>();
        productsBackUp = new List<GameObject>();

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Product");
        for (int i = 0; i < temp.Length; i++)
			{
                products.Add(temp[i]);
                productsBackUp.Add(temp[i]);
			}

        DeactivateItems();
    }

    void DeactivateItems()
    {
        foreach (var product in products)
	    {
	    	 product.SetActive(false);
	    }
    }

    void SpawnNextItem()
    {
        if(currentItems < maxItems && products.Count > 0)
        {
            if(spawnTimer <= 0)
            {
                nextItem = UnityEngine.Random.Range(0, products.Count);
                products[nextItem].SetActive(true);
                products[nextItem].GetComponent<Item>().TimeBoni = maxPoints;
                //currentItems++;
                spawnTimer = UnityEngine.Random.Range(0, 2);
            }

            spawnTimer -= 1.0f * Time.deltaTime;
        }

        else
        {
            products = new List<GameObject>(productsBackUp);
        }
    }

    void SearchActivProducts()
    {
        currentItems = GameObject.FindGameObjectsWithTag("Product").Length;
    }
}
