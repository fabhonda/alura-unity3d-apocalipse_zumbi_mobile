using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{

    public CaixaDeSom audio;

    public void AudioPasso()
    {
        audio.Tocar();
    }

    public void RotacaoJogador()
    {
        if (Direcao != Vector3.zero)
        {
            Vector3 posicaoMiraJogador = Direcao;
            posicaoMiraJogador.y = transform.position.y;
            Rotacionar(posicaoMiraJogador);
        }
    }
}
