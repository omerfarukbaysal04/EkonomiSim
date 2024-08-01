using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Nesne : MonoBehaviour
{
    public string nesneTuru;
    public AudioClip sesEfekti;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && sesEfekti != null)
        {
            audioSource.clip = sesEfekti;
        }
    }

    void OnMouseDown()
    {
        PuanKontrol.Instance.PuanEkle(nesneTuru);

        if (audioSource != null && sesEfekti != null)
        {
            audioSource.Play();
            StartCoroutine(DestroyAfterSound(audioSource.clip.length));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}



