using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class DataBaseHandler : ElSingleton<DataBaseHandler> {
    private int id_jugador;
    private int id_partida;
    private int id_jugadorHistorial;
    private int id_partidaHistorial;    
    public int actionNumber = 0;
    public Dropdown dropRef;
    public Dropdown dropRefH;

    static bool _onceCalled = false;

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

    // Use this for initialization
    void Start () {
     
    }

   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Debug.Log("id jugador: "+id_jugador +" id partida:"+ id_partida);
    }
 

    public void AgregarAccionBD(string name)
    {
        actionNumber++;
        var ds = dsConnect(); 
        ds.AddAction(name,id_jugador,id_partida,actionNumber);
        
    }

    public void CreateNewPlayer(string nick, string n, string a, int e, string m)
    {
        var ds = dsConnect();
        ds.CreatePlayer(nick, n, a, e, m);
    }

    public void CreateGame(string n)
    {
        var ds = dsConnect();
        ClearActionsOrders();
        id_jugador = GetPlayerIDByNick(dropRef.captionText.text);
        id_partida = ds.CreateGame(n, id_jugador).id;
    }

    public void UpdatePlayersDropdown(Dropdown drops)
    {
        drops.ClearOptions();
        dropRef = drops;
        var ds = dsConnect();
        drops.AddOptions(ds.GetPlayersNicks());
    }

    public void UpdatePlayersDropdownHistorial(Dropdown drops)
    {
        drops.ClearOptions();
        dropRef = drops;
        var ds = dsConnect();
        drops.AddOptions(ds.GetPlayersNicks());
    }

    public void UpdateGamesDropdown(string t, Dropdown drops)
    {
        drops.ClearOptions();
        dropRefH = drops; 
        var ds = dsConnect();
        Jugador p = ds.GetPlayerByNick(t);
        drops.AddOptions(ds.GetPlayersGames(p.id));
    }

    public int GetPlayerIDByNick(string nick)
    {
        var ds = dsConnect();
        return ds.GetPlayerByNick(nick).id;
    }

    public int GetGameIDByDate(string date)
    {
        var ds = dsConnect();
        return ds.GetGameByDate(date).id;
    }

    public void ClearActionsOrders()
    {
        actionNumber = 0;
    }

    public void UpdateScoreInDB(int score)
    {
        var ds = dsConnect();
        ds.AddPlayerScore(score, id_jugador, id_partida);
    }

    public DataService dsConnect()
    {
        return new DataService("jugadores.db");
    }

    public IEnumerable<Accion> GetActionsByPlayerAndGameID(int ij, int ip)
    {
        var ds = dsConnect();
        return ds.GetPlayerActionsByGame(ij, ip);
    }
}
