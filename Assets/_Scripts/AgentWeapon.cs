using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected float desiredAngle;

    [SerializeField]
    protected WeaponRenderer weaponRenderer;

    [SerializeField]
    protected Weapon weapon;

    private void Awake()
    {
        AssignWeapon();

    }
    private void AssignWeapon()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>(); //scripte ulaşıyoruz
        weapon = GetComponentInChildren<Weapon>();

    }
    public virtual void AimWeapon(Vector2 pointerPosition)// this will be the positon of our appointee that we received from our agent input.
    {
        var aimDirection = (Vector3)pointerPosition - transform.position;
        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; // arctan hesapladık dönmesi için trigonometerik işlemler oldu bu kodu arada yine incele red2deg de radius olarak hesapladığımız için onunla çarptık

        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward); // quaternion represent rotation
    }

    protected void AdjustWeaponRendering()
    {
        if (weaponRenderer != null)
        {
            weaponRenderer.FlipSprite(desiredAngle > 90 || desiredAngle < -90); // if weaponrenderer is not now du flipSprite.
            weaponRenderer.RenderBehindHead(desiredAngle < 180 && desiredAngle > 0);

        }

    }
    public void Shoot()
    {
        if (weapon != null)
        {
            weapon.TryShooting(); // this ? will simply check if weapon is not referencing null value, if it is not now it call shoot();.

        }


    }
    public void StopShooting()
    {
        if (weapon != null)
        {
            weapon?.StopShooting();


        }


    }
}
