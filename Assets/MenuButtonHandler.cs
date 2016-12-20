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
    public Button sgAceptButton;
    public Button sgCancelButton;

    [Header("Panels")]
    public GameObject JugarPartidaPanel;
    public GameObject Historial;
    public GameObject NewUser;
    [Header("Hover")]
    public GameObject HoverPanel;
    public Button HoverButton;


    // Use this for initialization
    void Start()
    {
        startGameButton.onClick.AddListener(() =>
        {
            GlobalPanelHandler.Instance.HoverShowUp(HoverPanel);
            GlobalPanelHandler.Instance.PanelShowUp(JugarPartidaPanel);
        });
        historialButton.onClick.AddListener(() =>
         {
             GlobalPanelHandler.Instance.HoverShowUp(HoverPanel);
             GlobalPanelHandler.Instance.PanelShowUp(Historial);
         });

        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        sgCancelButton.onClick.AddListener(() =>
        {
            GlobalPanelHandler.Instance.HoverShowOff(HoverPanel);
            GlobalPanelHandler.Instance.PanelShowOff();
           
        });

       HoverButton.onClick.AddListener(() =>
       {
           GlobalPanelHandler.Instance.HoverShowOff(HoverPanel);
           GlobalPanelHandler.Instance.PanelShowOff();

       });

        sgAceptButton.onClick.AddListener(() =>
        {
            SCManager.Instance.LoadScene("game1");
        });

    }

}
