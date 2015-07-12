using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shopping_Manager : MonoBehaviour 
{
    private List<GameObject> products;
    private List<GameObject> productsBackUp;
    private int currentItems;
    private int maxItems;
    private int nextItem;
    private float spawnTimer = 3;

    void Awake()
    {
        FindAvailableProducts();
    }

    void Update()
    {
        SpawnNextItem();
    }

    public List<GameObject> Products
    {
        get { return products;}
        set { products = value;}
    }

    public int CurrentItem
    {
        get { return currentItems;}
        set {  currentItems = value; }
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
        if(currentItems <= maxItems && products.Count > 0)
        {
            if(spawnTimer <= 0)
            {
                nextItem = Random.Range(0, products.Count);
                products[nextItem].SetActive(true);
                currentItems++;
                spawnTimer = Random.Range(0, 4);
            }

            spawnTimer -= 1.0f * Time.deltaTime;
        }

        else if(Products.Count == 0)
        {
            products = new List<GameObject>(productsBackUp);
        }
    }
}
