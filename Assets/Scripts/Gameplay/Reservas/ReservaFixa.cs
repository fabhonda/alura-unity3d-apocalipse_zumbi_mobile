using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaFixa : MonoBehaviour, IReservaObjetos
{

    public GameObject prefab;
    public int quantidade;
    private Stack<GameObject> reserva;

    void Awake()
    {
        this.reserva = new Stack<GameObject>();
        this.CriarTodosObjetos();
    }

    private void CriarTodosObjetos()
    {
        for(var i = 0; i < quantidade; i++)
        {
            CriarNovoObjeto();
        }
    }

    private void CriarNovoObjeto()
    {
        var objeto = GameObject.Instantiate(this.prefab, this.transform);
        var objetoReservavel = objeto.GetComponent<IReservavel>();
        objetoReservavel.SetReserva(this);
        this.DevolverObjeto(objeto);
    }

    public void DevolverObjeto(GameObject objeto)
    {
        var objetoReservavel = objeto.GetComponent<IReservavel>();
        objetoReservavel.AoEntrarNaReserva();
        reserva.Push(objeto);
    }

    public GameObject PegarObjeto()
    {
        var objeto = this.reserva.Pop();
        var objetoReservavel = objeto.GetComponent<IReservavel>();
        objetoReservavel.AoSairDaReserva();
        return objeto;
    }
    
    public bool TemObjeto()
    {
        return reserva.Count > 0;
    }
}
