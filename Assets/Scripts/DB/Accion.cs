using SQLite4Unity3d;

public class Accion {

    [PrimaryKey, AutoIncrement, NotNull]
    public int id { get; set; }
    public int Numero { get; set; }
    public string Nombre { get; set; }
    [Indexed]
    public int id_Jugador { get; set; }
    [Indexed]
    public int id_Partida { get; set; } 

}
