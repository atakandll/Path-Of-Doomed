using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAmmo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text = null;

    public void UpdateBulletText(int bulletCount)
    {
        if (bulletCount <= 0)
        {
            text.color = Color.black;
        }
        else
        {
            text.color = Color.white;
        }
        text.SetText(bulletCount.ToString());

    }

}
