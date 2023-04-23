using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCinemachineFeedback : FeedBack
{
    [SerializeField]
    private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField]

    [Range(0, 10)]
    private float amplitude = 1, intensity = 1;
    [SerializeField]
    [Range(0, 1)]
    private float duration = 0.1f;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        if (cinemachineCamera == null)
        {
            cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        }
        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }
    public override void CompletePreviousFeedBack()
    {
        StopAllCoroutines();
        noise.m_AmplitudeGain = 0; // we dont any shake by default
    }

    public override void CreateFeedBack()
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = intensity;
        StartCoroutine(ShakeCoroutine());

    }
    IEnumerator ShakeCoroutine()
    {
        for (float i = duration; i > 0; i -= Time.deltaTime)
        {
            noise.m_AmplitudeGain = Mathf.Lerp(0, amplitude, i / duration); // smooth bi şekilde 0 dan amplitude yapıcak ve bu i/ duration ile yapıcak.
            yield return null; // we are going to do this every frame until we reached the end of the loop

        }
        noise.m_AmplitudeGain = 0;

    }
}
