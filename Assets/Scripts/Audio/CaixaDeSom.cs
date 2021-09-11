using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CaixaDeSom : MonoBehaviour
{
    public AudioClip[] listaAudio;
    private AudioSource saidaAudio;

    private void Awake()
    {
        saidaAudio = GetComponent<AudioSource>();
    }

    public void Tocar()
    {
        var sorteado = Random.Range(0, listaAudio.Length);
        saidaAudio.PlayOneShot(listaAudio[sorteado]);
    }
}
