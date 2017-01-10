using UnityEngine;
using System.Collections;

public class PlayerScoreHandler : ElSingleton<PlayerScoreHandler> {

    private int puntaje=10000;
    private int puntajeTotalPosible=13000;

    public int Puntaje
    {
        get
        {
            return puntaje;
        }

        set
        {
            puntaje = value;
        }
    }

    public string CalculatePlayerPerformance()
    {
        float p = (puntaje / puntajeTotalPosible) * 100;
        string s = p.ToString() + "%";
        return s; 
    }

    public void AddScore(int s)
    {
        puntaje += s;
    }

    public void DecreaseScore(int s)
    {
        Puntaje -= s;
    }
}
