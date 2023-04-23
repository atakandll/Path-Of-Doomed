using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectToSpawn;

    [SerializeField]
    protected int poolSize;

    [SerializeField]
    protected int currentSize;

    [SerializeField]
    protected Queue<GameObject> objectPool; //ilk giren ilk çıkar işleyişine sahip bir koleksiyondur. Koleksiyondan bir eleman çıkarılmak istenildiğinden, kuyruğun en önünde yer eleman çıkartılacaktır. Yeni eklenmek istenen bir eleman ise kuyruğun en sonuna eklenecektir.

    private void Awake()
    {
        objectPool = new Queue<GameObject>();


    }
    public virtual GameObject SpawnObject(GameObject currentObject = null) // Virtual olarak tanımladığımız metodlarımızı, diğer class larda override edebiliriz.
    {
        if (currentObject == null)
        {
            currentObject = objectToSpawn;
        }
        GameObject spawnedObject = null;

        if (currentSize < poolSize)
        {
            spawnedObject = Instantiate(currentObject, transform.position, Quaternion.identity);
            spawnedObject.name = currentObject.name + "_" + currentSize;
            currentSize++;
        }
        else
        {
            spawnedObject = objectPool.Dequeue(); //  Kuyruğun başındaki öğeyi döndürür ve sonra öğe kuyruktan çıkarılır/silinir.
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;



        }
        objectPool.Enqueue(spawnedObject); // Parametre olarak girilen öğeyi kuyruğun sonuna eklemektedir
        return spawnedObject;


    }
}
