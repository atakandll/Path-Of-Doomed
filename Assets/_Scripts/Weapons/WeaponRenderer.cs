using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField]
    protected int playerSortingOrder = 0;
    protected SpriteRenderer weaponRenderer;

    private void Awake()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool val)
    {
        int flipModifier = val ? -1 : 1;
        transform.localScale = new Vector3(transform.localScale.x, flipModifier * Mathf.Abs(transform.localScale.y), transform.localScale.z);

    }
    public void RenderBehindHead(bool val) // this will ensure that we can render our weapon in front or beind our player avatar. 
    {
        if (val)
        {
            weaponRenderer.sortingOrder = playerSortingOrder - 1;

        }
        else
        {
            weaponRenderer.sortingOrder = playerSortingOrder + 1;
        }
    }



}
