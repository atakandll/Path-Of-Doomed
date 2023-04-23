using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour // this class it will say to the bullet how it will act
{
    [SerializeField]
    protected BulletDataSO bulletData; // so we can assign to it the data and we weill able to send it thorıgh the script using  BulletData property.
    public virtual BulletDataSO BulletData //virtual mean that we can modify how our data behaves now
    {
        get { return bulletData; }
        set { bulletData = value; }
    }


    // [field: SerializeField]
    // public  virtual BulletDataSO BulletData { get; set; }

}
