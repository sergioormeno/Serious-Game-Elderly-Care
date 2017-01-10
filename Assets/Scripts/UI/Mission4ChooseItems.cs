using UnityEngine;
using UnityEngine.UI;
using System.Collections; 

public class Mission4ChooseItems : MonoBehaviour
{

    public Button aceptB;
    [Header("ToggleButtons")]
    public Toggle t1;
    public Toggle t2;
    public Toggle t3;
    public Toggle t4;
    public Toggle t5;
    public Toggle t6;
    public Toggle t7;
    public Toggle t8;
    [Header("GameObjects")]
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    public GameObject g5;
    public GameObject g6;
    public GameObject g7;
    public GameObject g8;

    GameStatus gs;




    void Start()
    {
        gs = GameStatus.Instance;
        CameraHandler ch = CameraHandler.Instance;

        aceptB.onClick.AddListener(() =>
        {
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0, 0.5f).setOnComplete(() =>
            {
                gameObject.SetActive(false);
            });
            ch.FirstPersonMode = true;
            gs.Stat.Duchar = 1;
            SaveChoicesInPlayerActions();            
        });

        t1.onValueChanged.AddListener((b) => g1.SetActive(b));
        t2.onValueChanged.AddListener((b) => g2.SetActive(b));
        t3.onValueChanged.AddListener((b) => g3.SetActive(b));
        t4.onValueChanged.AddListener((b) => g4.SetActive(b));
        t5.onValueChanged.AddListener((b) => g5.SetActive(b));
        t6.onValueChanged.AddListener((b) => g6.SetActive(b));
        t7.onValueChanged.AddListener((b) => g7.SetActive(b));
        t8.onValueChanged.AddListener((b) => g8.SetActive(b));
    }

    public IEnumerator  SaveChoicesInPlayerActions()
    {
        if (t1.isOn) gs.playerActions.Actions = "ha elegido el antidezlisante";
        if (t2.isOn) gs.playerActions.Actions = "ha elegido el jabon";
        if (t3.isOn) gs.playerActions.Actions = "ha elegido la lampara";
        if (t4.isOn) gs.playerActions.Actions = "ha elegido la linterna";
        if (t5.isOn) gs.playerActions.Actions = "ha elegido la radio";
        if (t6.isOn) gs.playerActions.Actions = "ha elegido el champu";
        if (t7.isOn) gs.playerActions.Actions = "ha elegido la silla de soporte";
        if (t8.isOn) gs.playerActions.Actions = "ha elegido la toalla";
        else gs.towelonChooseItems = false;
        yield return new WaitForSeconds(1f);
    }

}
