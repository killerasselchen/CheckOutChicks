//Coder: Timo Fabricius
//Contact: Timo.Fabricius@gmx.de
//Project: CheckOut Chicks
//GPD414 at SAE Hamburg 04/2014-10/2015

using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    private int currentItems = 0;

    private int maxItems;

    private float maxPoints;

    private int nextItem;

    [SerializeField]
    private GameObject[] products;

    private Queue<int> queue;

    private float spawnTimer;

    public int MaxItems
    {
        get { return maxItems; }
        set { maxItems = value; }
    }

    public void Awake()
    {
        queue = new Queue<int>();
        spawnTimer = 0;
        maxItems = 1;
        maxPoints = 30;
    }

    public void EnqueueItem(GameObject item)
    {
        currentItems--;
        Arrow.target.Equals(null);
        queue.Enqueue(Random.Range(0, products.Length));
        item.SetActive(false);
    }

    public void Initialize()
    {
        queue.Clear();
        products = GameObject.FindGameObjectsWithTag("Product");
        int[] indices = new int[products.Length];

        for (int i = 0; i < products.Length; i++)
        {
            indices[i] = i;
        }
        for (int i = 0; i < products.Length; i++)
        {
            int temp = indices[i];
            int swap = Random.Range(0, products.Length);
            indices[i] = indices[swap];
            indices[swap] = temp;
        }
        for (int i = 0; i < products.Length; i++)
        {
            queue.Enqueue(indices[i]);
            products[indices[i]].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        SpawnNextItem();
    }

    private void SpawnNextItem()
    {
        if (queue.Count == 0 || currentItems >= maxItems) return;

        if (spawnTimer <= 0)
        {
            currentItems++;
            nextItem = queue.Dequeue();
            products[nextItem].SetActive(true);
            Arrow.target = products[nextItem].transform.position;
            MainUIElements.currentItem = products[nextItem];
            products[nextItem].GetComponent<Item>().TimeBoni = maxPoints;
            spawnTimer = UnityEngine.Random.Range(1, 3);
        }

        spawnTimer -= 1.0f * Time.fixedDeltaTime;
    }
}