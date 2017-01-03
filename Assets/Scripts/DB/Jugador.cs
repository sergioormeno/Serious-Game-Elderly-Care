using SQLite4Unity3d;

public class Jugador {

    [PrimaryKey, AutoIncrement, NotNull]
    public int id { get; set; }
    [Unique]
    public string Nick { get; set; }
    [NotNull]
    public string Nombre { get; set; }
    [NotNull]
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Correo { get; set; }

    public override string ToString()
    {
        return string.Format("[Jugador: Id={0}, Nick={1},  Nombre={2}, Apellido={3}, Edad={4}, Correo={5}]", id, Nick, Nombre, Apellido,Edad,Correo);
    }

}

