using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {

    public ReservaExtensivel reservaDeBalas;
    public GameObject Bala;
    public GameObject CanoDaArma;
    public AudioClip SomDoTiro;

	
	// Update is called once per frame
	void Update () {
        var toquesNaTela = Input.touches;
        foreach(var toque in toquesNaTela)
        {
            if(toque.phase == TouchPhase.Began)
            {
                Atirar();
                ControlaAudio.instancia.PlayOneShot(SomDoTiro);
            }
        }
	}
    
    private void Atirar()
    {
        if (reservaDeBalas.TemObjeto())
        {
            var bala = reservaDeBalas.PegarObjeto();
            bala.transform.position = CanoDaArma.transform.position;
            bala.transform.rotation = CanoDaArma.transform.rotation;
        }
    }
}
