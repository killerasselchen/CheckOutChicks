using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shopping_Manager : MonoBehaviour 
{
    private List<GameObject> products = new List<GameObject>();
    private List<GameObject> productsCopie;
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

    //public int NextItem
    //{
    //    get { return nextItem; }
    //    set { value = nextItem; }
    //}

    public List<GameObject> Products
    {
        get { return products;}
        set { value = products;}
    }

    public int CurrentItem
    {
        get { return currentItems;}
        set { value = currentItems; }
    }

    public int MaxItems
    {
        get { return maxItems;}
        set { value = maxItems; }
    }

    void FindAvailableProducts()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Product");
        for (int i = 0; i < temp.Length; i++)
			{
                products.Add(temp[i]);
			}

        productsCopie = products;

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
        if(currentItems <= maxItems && Products.Count > 1)
        {
            if(spawnTimer <= 0)
            {
                nextItem = Random.Range(0, products.Count);
                products[nextItem].SetActive(true);

                CurrentItem++;
                spawnTimer = Random.Range(0, 4);
            }

            spawnTimer -= 1.0f * Time.deltaTime;
        }

        else if(Products.Count == 0)
        {
            Products = productsCopie;
        }
    }
}
