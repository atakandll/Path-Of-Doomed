using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{

    protected Rigidbody2D rigidbody2D;
    private bool isDead = false;

    public override BulletDataSO BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.drag = BulletData.Friction;
        }

    }
    private void FixedUpdate()
    {
        if (rigidbody2D != null && BulletData != null)
        {
            rigidbody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime); // moveposition yaptık çünkü bulletları kinematic yaptık velocityye ulaşamıyoruz
        }

    }
    private void OnTriggerEnter2D(Collider2D other)  // bulletslar kinematic olduğu için triggerdan yaptık
    {
        if (isDead)
        {
            return;
        }
        isDead = true; // this will protect us from two enemies being hit at once

        var hittable = other.GetComponent<IHittable>(); // var is just a undefined type so we are going to take the type whatever is returned to us 

        hittable?.GetHit(bulletData.Damage, gameObject); // enemye hasar verdiğimiz kısım.

        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            HitObstacles(other);

        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(other);
        }
        Destroy(gameObject);

    }
    private void HitEnemy(Collider2D other)
    {
        var knockback = other.GetComponent<IKnockback>();
        knockback?.Knockback(transform.right, BulletData.KnockBackPower, BulletData.KnockBackDelay); // mermiler sağ yönde
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f; // enemy vurunca efekt çıkması için
        Instantiate(BulletData.ImpactEnemyPrefab, other.transform.position + (Vector3)randomOffset, Quaternion.identity);


    }
    private void HitObstacles(Collider2D other)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1, bulletData.BulletLayerMask); // sağ yaptık çübkü mermiler sağa doğru
        if (hit.collider != null)
        {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);

        }

    }

}
