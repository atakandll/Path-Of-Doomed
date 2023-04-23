using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : AgentWeapon
{
    [SerializeField]
    private UIAmmo uiAmmo = null;

    public bool AmmoFull { get => weapon != null && weapon.AmmoFull; } // cephane full olduğunda yapılacak kısım

    private void Start()
    {
        if (weapon != null)
        {
            weapon.OnAmmoChange.AddListener(uiAmmo.UpdateBulletText);
            uiAmmo.UpdateBulletText(weapon.Ammo);
        }

    }

    public void AddAmmo(int amount) // mermi eklenecek kısım
    {
        if (weapon != null)
            weapon.Ammo += amount;
    }

}
