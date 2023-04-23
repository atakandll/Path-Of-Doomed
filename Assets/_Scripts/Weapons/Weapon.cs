using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour // this scripts responsible for firing bullets from our weapon.
{
    [SerializeField]
    protected GameObject muzzle;

    [SerializeField]
    protected int ammo = 10; // ammunition = cephane

    [SerializeField]
    protected WeaponDataSO weaponData;

    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapasity);
            OnAmmoChange?.Invoke(ammo);

        }
    }

    public bool AmmoFull { get => Ammo >= weaponData.AmmoCapasity; } // cephane full anlamına geliyor get içindeki kodlar
    protected bool isShooting = false;
    [SerializeField]
    protected bool reloadCoroutine = false;

    [field: SerializeField]
    public UnityEvent OnShoot { get; set; } // ateş edilirken kullanılacak event

    [field: SerializeField]
    public UnityEvent OnShootNoAmmo { get; set; } // cephane bittiğinde kullanılcak event

    [field: SerializeField]
    public UnityEvent<int> OnAmmoChange { get; set; } // cephane sayıısnı değiştireceğimiz yer.

    private void Start()
    {
        Ammo = weaponData.AmmoCapasity; // we have all the bullets that we need in start.

    }

    public void TryShooting()
    {
        isShooting = true;

    }
    public void StopShooting()
    {
        isShooting = false;

    }
    public void Reload(int ammo)
    {
        Ammo += ammo;

    }
    private void Update()
    {
        UseWeapon();




    }

    private void UseWeapon()
    {
        if (isShooting && reloadCoroutine == false) // silahı kullanmak için ateş etmem ve reload yapmamam gerekiyor
        {
            if (Ammo > 0) // cephane 0 dan büyükse
            {
                Ammo--;
                OnShoot?.Invoke();
                for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();

                }

            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;

            }
            FinishShooting();
        }

    }

    private void FinishShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());

        if (weaponData.AutomaticFire == false)
        {
            isShooting = false; // player ateş etmesi için bir kez daha basması gerekecek
        }
    }

    protected IEnumerator DelayNextShootCoroutine()
    {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        reloadCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculeAngle(muzzle));

    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        var bulletPrefab = Instantiate(weaponData.BulletData.bulletPrefab, position, rotation);
        bulletPrefab.GetComponent<Bullet>().BulletData = weaponData.BulletData;
    }
    private Quaternion CalculeAngle(GameObject muzzle) // quaterniton represent rotation
    {
        float spread = Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle); // to the left to the right

        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));

        return muzzle.transform.rotation * bulletSpreadRotation; // return is the angle at which we should spawn our object
    }

}
