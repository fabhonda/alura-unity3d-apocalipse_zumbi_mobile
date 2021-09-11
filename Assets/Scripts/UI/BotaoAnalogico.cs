using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BotaoAnalogico : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform imagemFundo;
    public RectTransform imagemElipse;
    public MeuEventoDinamicoVector2 QuandoOValorMudar;
    public void OnDrag(PointerEventData dadosMouse)
    {
        var posicaoMouse = CalcularPosicaoMouse(dadosMouse);
        var posicaoLimitada = LimitarPosicao(posicaoMouse);
        PosicionarJoystick(posicaoLimitada);
        QuandoOValorMudar.Invoke(posicaoLimitada);
    }

    private Vector2 LimitarPosicao(Vector2 posicaoMouse)
    {
        var posicaoLimitada = posicaoMouse/TamanhoImagem();
        if(posicaoLimitada.magnitude > 1) posicaoLimitada = posicaoLimitada.normalized;
        return posicaoLimitada;
    }

    private float TamanhoImagem()
    {
        return imagemFundo.rect.width / 2;
    }

    private void PosicionarJoystick(Vector2 posicaoMouse)
    {
        imagemElipse.localPosition = posicaoMouse * TamanhoImagem();
    }

    private Vector2 CalcularPosicaoMouse(PointerEventData dadosMouse)
    {
        Vector2 posicao;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imagemFundo, dadosMouse.position, dadosMouse.enterEventCamera, out posicao);

        return posicao;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PosicionarJoystick(Vector2.zero);
        QuandoOValorMudar.Invoke(Vector2.zero);
    }

    public void OnPointerDown(PointerEventData dadosMouse)
    {
        OnDrag(dadosMouse);
    }
}

[Serializable]
public class MeuEventoDinamicoVector2 : UnityEvent<Vector2> { }
