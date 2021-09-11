using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaExtensivel : MonoBehaviour, IReservaObjetos
{
    public GameObject prefab;
    private Stack<GameObject> reserva;

    void Awake()
    {
        reserva = new Stack<GameObject>();
    }

    private void CriarNovoObjeto()
    {
        var objeto = GameObject.Instantiate(prefab, this.transform);
        var objetoReservavel = GetComponent<IReservavel>();
        objetoReservavel.SetReserva(this);
        DevolverObjeto(objeto);
    }

    public void DevolverObjeto(GameObject objeto)
    {
        var objetoReservavel = objeto.GetComponent<IReservavel>();
        objetoReservavel.AoEntrarNaReserva();
        reserva.Push(objeto);
    }

    public GameObject PegarObjeto()
    {
        if (reserva.Count <= 0) CriarNovoObjeto();
        var objeto = this.reserva.Pop();
        var objetoReservavel = objeto.GetComponent<IReservavel>();
        objetoReservavel.AoSairDaReserva();
        return objeto;
    }

    public bool TemObjeto()
    {
        return true;
    }
}
