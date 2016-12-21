using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameMenú : MonoBehaviour
{
    bool menuIsOn = false;
    bool paused = false;
    [Header("Paneles")]
    public GameObject menuPanel;
    [Header("Buttons")]
    public Button continuar;
    public Button exitGame;
    public Button goMainMenu;
    [Header("Hover")]
    public GameObject hoverPanel;
    public Button hoverPButton;

    [Header("EndGamePanel")]
    public GameObject endGamePanel;
    public Button guardarSalir;
    public Button exportarHistorial;
    public Button playAgain;
    public Button menuPrincipal;

    void Start()
    {
        continuar.onClick.AddListener(() =>
        {
            displayInGameMenu(menuIsOn);
        });

        goMainMenu.onClick.AddListener(() => SCManager.Instance.LoadScene(SCManager.Instance.ReturnLastSceneName()));

        exitGame.onClick.AddListener(() => Application.Quit());

        StartCoroutine(EndGameChecker());

        guardarSalir.onClick.AddListener(() => SaveExit());

        playAgain.onClick.AddListener(() => SCManager.Instance.LoadScene("game1"));

        menuPrincipal.onClick.AddListener(() => SCManager.Instance.LoadScene("start"));
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Diary.Instance.counter >= 1)
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
                CameraHandler.Instance.FirstPersonMode = true;
                GlobalPanelHandler.Instance.HoverShowOff(hoverPanel);
                GlobalPanelHandler.Instance.PanelShowOff();
                menuIsOn = false;
                break;
            case false:
                SwitchPaused(paused);
                if (Diary.Instance.open) Diary.Instance.displayDiary(Diary.Instance.open);
                CameraHandler.Instance.FirstPersonMode = false;
                GlobalPanelHandler.Instance.PanelShowUp(menuPanel);
                GlobalPanelHandler.Instance.HoverShowUp(hoverPanel);
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
        while(GameStatus.Instance.Stat.Duchar != 6) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(4f);
        if (Diary.Instance.open) Diary.Instance.displayDiary(Diary.Instance.open);
        CameraHandler.Instance.FirstPersonMode = false;
        hoverPButton.enabled = false;
        GlobalPanelHandler.Instance.HoverShowUp(hoverPanel);
        GlobalPanelHandler.Instance.PanelShowUp(endGamePanel);
    }

    public void SaveExit()
    {
        Application.Quit();
    }
}