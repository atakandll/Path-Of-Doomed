using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletSheelGenerator : ObjectPool
{
    [SerializeField]
    private float fylDuration = 0.3f;
    [SerializeField]
    private float flyStrenght = 1;

    public void SpawnBulletShell()
    {
        var shell = SpawnObject();
        MoveShellInRandomDirection(shell);
    }

    private void MoveShellInRandomDirection(GameObject shell)
    {
        shell.transform.DOComplete();
        var randomDirection = Random.insideUnitCircle;
        randomDirection = randomDirection.y > 0 ? new Vector2(randomDirection.x, -randomDirection.y) : randomDirection; // if else statement;

        shell.transform.DOMove(((Vector2)transform.position + randomDirection) * flyStrenght, fylDuration).OnComplete(() => shell.GetComponent<AudioSource>().Play()); // this will be direction at which we want to make our bullet fly.
        shell.transform.DORotate(new Vector3(0, 0, Random.Range(0f, 360f)), fylDuration);
    }
}
