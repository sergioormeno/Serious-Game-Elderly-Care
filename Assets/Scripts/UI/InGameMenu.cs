using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    bool menuIsOn = false, paused = false;
    [Header("Paneles")]
    public GameObject menuPanel;
    [Header("Buttons")]
    public Button continuar, exitGame, goMainMenu;
    [Header("Hover")]
    public GameObject hoverPanel;
    public Button hoverPButton;

    [Header("EndGamePanel")]
    public GameObject endGamePanel;
    public Button guardarSalir, playAgain, menuPrincipal;

    GlobalPanelHandler ph;
    SCManager sm;
    CameraHandler ch;
    WinstonStats ws;
    DiaryAnimation da;
    GameStatus gs;

    void Start()
    {
        ph = GlobalPanelHandler.Instance;
        sm = SCManager.Instance;
        ch = CameraHandler.Instance;
        ws = WinstonStats.Instance;
        gs = GameStatus.Instance;
        da = DiaryAnimation.Instance;


        continuar.onClick.AddListener(() =>
        {
            displayInGameMenu(menuIsOn);
        });

        goMainMenu.onClick.AddListener(() => sm.LoadScene(sm.ReturnLastSceneName()));

        exitGame.onClick.AddListener(() => Application.Quit());

        StartCoroutine(EndGameChecker());

        guardarSalir.onClick.AddListener(() => SaveExit());

        playAgain.onClick.AddListener(() => sm.LoadScene("game1"));

        menuPrincipal.onClick.AddListener(() => sm.LoadScene("start"));
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (da.counter >= 1)
            {
                displayInGameMenu(menuIsOn);
            }
        }
    }

    void displayInGameMenu(bool isOn)
    {
        switch (isOn)
        {
            case true:
                SwitchPaused(paused);
                ch.FirstPersonMode = true;
                ph.HoverShowOff(hoverPanel);
                ph.PanelShowOff();
                menuIsOn = false;
                break;
            case false:
                SwitchPaused(paused);
                if (da.open) da.displayDiary(da.open);
                ch.FirstPersonMode = false;
                ph.PanelShowUp(menuPanel);
                ph.HoverShowUp(hoverPanel);
                menuIsOn = true;
                break;
        }
    }

    void SwitchPaused(bool paused)
    {
        Debug.Log("paused" + paused);
    }

    public IEnumerator EndGameChecker()
    {
        while(!gs.endGame) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(4f);
        if (da.open) da.displayDiary(da.open);
        ch.FirstPersonMode = false;
        hoverPButton.enabled = false;
        ph.HoverShowUp(hoverPanel);
        ph.PanelShowUp(endGamePanel);
        ws.StopAllCoroutines();
    }

    public void SaveExit()
    {
        Application.Quit();
    }
}