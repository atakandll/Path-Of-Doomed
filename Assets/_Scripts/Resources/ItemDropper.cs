using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Linq;

public class ItemDropper : MonoBehaviour // list olucak o ve o listten seçip random olarak düşürücez
{
    [SerializeField]
    private List<ItemSpawnData> itemsToDrop = new List<ItemSpawnData>();
    float[] itemWeights;

    [SerializeField]
    [Range(0, 1)]
    private float dropChance = 0.5f;

    private void Start()
    {
        itemWeights = itemsToDrop.Select(item => item.rate).ToArray();
    }

    public void DropItem()
    {
        var dropVariable = Random.value;
        if (dropVariable < dropChance)
        {
            int index = GetRandomWeightedIndex(itemWeights);
            Instantiate(itemsToDrop[index].itemPrefab, transform.position, Quaternion.identity);
        }
    }

    private int GetRandomWeightedIndex(float[] itemWeights)
    {
        float sum = 0f;
        for (int i = 0; i < itemWeights.Length; i++)
        {
            sum += itemWeights[i];
        }
        float randomValue = Random.Range(0, sum);
        float tempSum = 0;

        for (int i = 0; i < itemsToDrop.Count; i++)
        {
            //0->0+Weight[0] item 1 (0->0.5)
            //Weight[0]-> Weight[0]+Weight[1](0.5 -> 0.7)
            //tempSum -> tempSu + Weights[N]
            if (randomValue >= tempSum && randomValue < tempSum + itemWeights[i])
            {
                return i;
            }
            tempSum += itemWeights[i];
        }
        return 0;
    }


}


[Serializable]
public struct ItemSpawnData
// this will allow us to create a in the ınspector, a pair of values
// bir yapı oluştururken bu yapılar bibrileriyle ilşkiliyse, structlar class gibi ama daha basit yapılar tutulacak verile enkapsüle tmek yetiyorsa 
{
    [Range(0, 1)]
    public float rate;
    public GameObject itemPrefab;

}
