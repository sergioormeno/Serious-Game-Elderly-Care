using SQLite4Unity3d;

public class Partida
{
    [PrimaryKey, AutoIncrement,Unique]
    public int id { get; set; }
    public string Nombre { get; set; }
    [Indexed]
    public int id_Jugador { get; set; }
    public string Fecha { get; set; }
    public int Puntaje { get; set; }
}


