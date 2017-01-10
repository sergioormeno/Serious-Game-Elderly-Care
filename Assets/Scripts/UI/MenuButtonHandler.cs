using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    [Header("Botones Menú")]
    public Button startGameButton;
    public Button historialButton;
    public Button exitButton;
    [Header("Botones Jugar Partida")]
    public Button ngAceptButton;
    public Button ngCancelButton;
    public Button ngNewUser;

    [Header("Panels")]
    public GameObject JugarPartidaPanel;
    public GameObject Historial;
    public GameObject NewUser;
    [Header("Hover")]
    public GameObject HoverPanel;
    public Button HoverButton;

    [Header("DropdownMenúPlayers")]
    public Dropdown playersDrops;


    // Use this for initialization
    void Start()
    {
        GlobalPanelHandler ph = GlobalPanelHandler.Instance;
        DataBaseHandler db = DataBaseHandler.Instance;
        SCManager sm = SCManager.Instance;

        startGameButton.onClick.AddListener(() =>
        {
            ph.HoverShowUp(HoverPanel);
            ph.PanelShowUp(JugarPartidaPanel);
        });
        historialButton.onClick.AddListener(() =>
         {
            ph.HoverShowUp(HoverPanel);
            ph.PanelShowUp(Historial);
         });

        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

       HoverButton.onClick.AddListener(() =>
       {
          ph.HoverShowOff(HoverPanel);
          ph.PanelShowOff();

       });

        ngAceptButton.onClick.AddListener(() =>
        {
            db.CreateGame("Game1");
            sm.LoadScene("game1");
        });

        ngCancelButton.onClick.AddListener(() =>
        {
            ph.HoverShowOff(HoverPanel);
            ph.PanelShowOff();            
        });

       db.UpdatePlayersDropdown(playersDrops);

        ngNewUser.onClick.AddListener(() =>
        {
            ph.PanelShowUp(NewUser);
        });

        


    }

}
