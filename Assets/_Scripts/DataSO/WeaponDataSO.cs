using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField]
    public BulletDataSO BulletData { get; set; } // bulletdata referansına sahibiz.

    [field: SerializeField]
    [field: Range(0, 100)] // ammocapasityi 0 yapmayacak.
    public int AmmoCapasity { get; set; } = 100;

    [field: SerializeField]
    public bool AutomaticFire { get; set; } = false;

    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; set; } = 0.1f;

    [field: SerializeField]
    [field: Range(0, 10)]
    public float SpreadAngle { get; set; } = 5; // this will be the angle of spread of our bullets

    [SerializeField]
    private bool multiBulletShot = false;

    [SerializeField]
    [Range(1, 10)]
    private int bulletCount = 1;

    internal int GetBulletCountToSpawn()
    {
        if (multiBulletShot)
        {
            return bulletCount;
        }
        return 1;
    }
}
