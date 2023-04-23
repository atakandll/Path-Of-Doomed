using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    [SerializeField]
    private AudioClip shootBulletClip = null, outOfBulletClip = null;

    public void PlayShootSound()
    {
        PlayClip(shootBulletClip);
    }
    public void PlayNoBulletsSound()
    {
        PlayClip(outOfBulletClip);
    }

}
