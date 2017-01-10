using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HistoryPanelHandler : MonoBehaviour
{
    [Header("Action Prefab things")]
    public GameObject ActionPrefab;
    public GameObject ContentHolderParent;
    public Dropdown Jugadores;
    public Dropdown Partidas;

    public Button buscarHistorial;
    public Button volver;

    public GameObject HoverPanel;
    DataBaseHandler dbh;
    GlobalPanelHandler ph;


    // Use this for initialization
    void Start()
    {
        dbh = DataBaseHandler.Instance;
        ph = GlobalPanelHandler.Instance;

        dbh.UpdatePlayersDropdown(Jugadores);
        Jugadores.onValueChanged.AddListener((b) =>
        {
            dbh.UpdateGamesDropdown(Jugadores.captionText.text, Partidas);
        });
       dbh.UpdateGamesDropdown(Jugadores.captionText.text, Partidas);

        volver.onClick.AddListener(() =>
        {
            ph.HoverShowOff(HoverPanel);
           ph.PanelShowOff();            
        });

        buscarHistorial.onClick.AddListener(() => SearchHistory());

    }

    public void SearchHistory()
    {
        int idj = dbh.GetPlayerIDByNick(Jugadores.captionText.text);
        int idp = dbh.GetGameIDByDate(Partidas.captionText.text);
        StartCoroutine(AddActions(idj, idp));
    }

    public IEnumerator AddActions(int j, int p)
    {
        var a = dbh.GetActionsByPlayerAndGameID(j, p);
        foreach(var actions in a)
        {
            GameObject newAction = Instantiate(ActionPrefab);
            newAction.transform.SetParent(ContentHolderParent.transform);
            newAction.transform.GetChild(0).GetComponent<Text>().text = actions.Numero.ToString();
            newAction.transform.GetChild(1).GetComponent<Text>().text = actions.Nombre;
            newAction.transform.localPosition = Vector3.zero;
            newAction.transform.localRotation = Quaternion.identity;
            newAction.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
