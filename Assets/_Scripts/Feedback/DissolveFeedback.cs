using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DissolveFeedback : FeedBack
{
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;
    [SerializeField]
    private float duration = 0.05f;
    [field: SerializeField]
    public UnityEvent DeathCallBack { get; set; }
    public override void CompletePreviousFeedBack()
    {
        spriteRenderer.DOComplete();
        spriteRenderer.material.DOComplete();

    }
    public override void CreateFeedBack()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.material.DOFloat(0, "_Dissolve", duration));
        if (DeathCallBack != null)
        {
            sequence.AppendCallback(() => DeathCallBack.Invoke());
        }
    }
}
