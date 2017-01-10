using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HistoryPanelHandler : MonoBehaviour
{

    public GameObject ActionPrefab;
    public Dropdown Jugadores;
    public Dropdown Partidas;

    public Button buscarHistorial;
    public Button volver;

    public GameObject HoverPanel;




    // Use this for initialization
    void Start()
    {
        DataBaseHandler db = DataBaseHandler.Instance;
        GlobalPanelHandler ph = GlobalPanelHandler.Instance;

        db.UpdatePlayersDropdown(Jugadores);
        Jugadores.onValueChanged.AddListener((b) =>
        {
            db.UpdateGamesDropdown(Jugadores.captionText.text, Partidas);
        });
       db.UpdateGamesDropdown(Jugadores.captionText.text, Partidas);

        volver.onClick.AddListener(() =>
        {
            ph.HoverShowOff(HoverPanel);
           ph.PanelShowOff();            
        });

        buscarHistorial.onClick.AddListener(() => SearchHistory());

    }

    public void SearchHistory()
    {

    }
}
