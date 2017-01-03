using UnityEngine;
using System.Collections.Generic;

public class DataBaseHandler : ElSingleton<DataBaseHandler> {
    private int id_jugador;
    private int id_partida;
    public List<string> acciones;

    private bool _onceCalled = false;
    
    // Use this for initialization
    void Start () {
     
    }

    void Awake()
    {
        if (!_onceCalled)
        {
            DontDestroyOnLoad(gameObject);
            _onceCalled = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }


 
    public void CreateInfoGame(int id_j, int id_p)
    {
        id_jugador = id_j;
        id_partida = id_p; 
    }


    public void AgregarAccionesBD()
    {
        var ds = new DataService("juegoserio.db");
        foreach (string element in acciones)
        {
            ds.AddAction(element,id_jugador,id_partida);
        }
        ds = null;
    }

    public void CreateNewPlayer(string nick, string n, string a, int e, string m)
    {
        var ds = new DataService("juegoserio.db");
        ds.CreateJugador(nick, n, a, e, m);
        ds = null;
    }

    public void CrearPartida(string n)
    {
        var ds = new DataService("juegoserio.db");
        ds.CreateGame(n, id_jugador);
    }
}
