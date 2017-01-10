using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService
{
    public int actionNumber=0;
    private SQLiteConnection _connection;

    public DataService(string DatabaseName)
    {

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);

    }

    public void CreatePlayer(string nick, string name, string lname, int age, string mail)
    {
        var j = new Jugador
        {
            Nick = name,
            Nombre = name,
            Apellido = lname,
            Edad = age,
            Correo = mail,
        };
        _connection.Insert(j);
    }

    public void AddPlayerScore(int score, int id_J, int id_P)
    {
        Partida partida = _connection.Table<Partida>()
            .Where(x => x.id_Jugador == id_J && x.id == id_P)
            .FirstOrDefault();
        partida.Puntaje = score;
        _connection.Update(partida);
    }

    public void AddAction(string name, int id_J, int id_P,int num)
    {
        var a = new Accion
        {
            Numero = num,
            Nombre = name,          
            id_Jugador = id_J,
            id_Partida = id_P,            
        };
        _connection.Insert(a);
    }

    public Partida CreateGame(string name, int idj)
    {
        var p = new Partida
        {
            Nombre = name,
            id_Jugador = idj,
            Fecha = System.DateTime.Today.ToString(),
        };
        _connection.Insert(p);
        return p;
    }

    public IEnumerable<Jugador> GetJugador()
    {
        return _connection.Table<Jugador>();
    }

    public List<string> GetPlayersNicks()
    {
        List<string> nicks = new List<string>();
        var query = _connection.Table<Jugador>();
        foreach (var jugador in query) nicks.Add(jugador.Nick);
        return nicks;
    }

    public List<string> GetPlayersGames(int id)
    {
        List<string> games = new List<string>();
        var query = _connection.Table<Partida>().Where(x => x.id_Jugador == id);
        foreach (var partida in query) games.Add(partida.Fecha);
        return games;
    }

    public IEnumerable<Accion> GetPlayerActionsByGame(int id_j, int id_p)
    {
        return _connection.Table<Accion>().Where(x => x.id_Jugador == id_j &&  x.id_Partida == id_p);
    }

    public IEnumerable<Partida> GetGameByPlayer(int id_j)
    {
        return _connection.Table<Partida>().Where(x => x.id_Jugador == id_j);
    }

    public Jugador GetPlayerByNick(string n)
    {
        return _connection.Table<Jugador>().Where(x => x.Nick == n).First(); 
    }

}
