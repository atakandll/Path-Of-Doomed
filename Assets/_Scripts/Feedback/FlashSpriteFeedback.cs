using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSpriteFeedback : FeedBack
{
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;
    [SerializeField]
    private float flashTime = 0.1f;

    [SerializeField]
    private Material flashMaterial = null;

    private Shader originalMaterialShader;

    private void Start()
    {
        originalMaterialShader = spriteRenderer.material.shader;
    }
    public override void CompletePreviousFeedBack()
    {
        StopAllCoroutines();
        spriteRenderer.material.shader = originalMaterialShader;
    }

    public override void CreateFeedBack()
    {
        if (spriteRenderer.material.HasProperty("_MakeSolidColor") == false)
        {
            spriteRenderer.material.shader = flashMaterial.shader;
        }
        spriteRenderer.material.SetInt("_MakeSolidColor", 1); // 1 ile true yaptık
        StartCoroutine(WaitBeforeChangingBack());




    }
    IEnumerator WaitBeforeChangingBack()
    {
        yield return new WaitForSeconds(flashTime);
        if (spriteRenderer.material.HasProperty("_MakeSolidColor"))
        {
            spriteRenderer.material.SetInt("_MakeSolidColor", 0); // biraz bekledikten sonra rengi eski hali yaptık false yani 0 anlamı.
        }
        else
        {
            spriteRenderer.material.shader = originalMaterialShader; // make solid color yoksa eski original haline geri döndük

        }
    }
}
