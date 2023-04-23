using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Resource : MonoBehaviour
{
    [field: SerializeField]
    public ResourceDataSO ResourceData { get; set; }

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PickUpResource()
    {
        StartCoroutine(DestroyCorotuine());

    }

    IEnumerator DestroyCorotuine()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false; // ses bitene kadar bunlar da yok olucak.
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }
}
