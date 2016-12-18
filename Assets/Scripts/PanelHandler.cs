using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelHandler : ElSingleton<PanelHandler>
{
    public bool isOnAnimation = false;
    public Diary dr;
    public GameStatus gs;
    public CanvasGroup Ticket;
    public GameObject OpaquePanel;
    public GameObject DarkPanel;
    [Header("Tutorial")]
    public GameObject M0Tutorial;
    public GameObject M0TutorialP2;
    public Toggle tt1;
    public Toggle tt2;
    public CanvasGroup animCanvas1;
    public CanvasGroup animCanvas2;
    public CanvasGroup animCanvas3;
    private bool isDarkPanelActive = false;

    [Header("Fixing")]
    public GameObject M1Fixing;
    public Toggle tf1;
    public Toggle tf2;
    public Toggle tf3;


    [Header("Cooking")]
    public GameObject M2Cooking;
    public Toggle tc1;
    public Toggle tc2;
    public Toggle tc3;


    [Header("Bath")]
    public GameObject M3Bath;
    public Toggle tb1;
    public Toggle tb2;
    public Toggle tb3;
    public Toggle tb4;

    public bool IsDarkPanelActive
    {
        get
        {
            return isDarkPanelActive;
        }

        set
        {
            isDarkPanelActive = value;
            displayDarkPanel(isDarkPanelActive);
        }
    }

    void Start()
    {
        StartCoroutine(StarterAnimation());
        StartCoroutine(LinearQuest());
    }

    void Update()
    {

    }

    public IEnumerator StarterAnimation()
    {
        yield return new WaitForSeconds(4f);
        dr.open = true;
        LeanTween.moveX(dr.Panel1.GetComponent<RectTransform>(), -180, 0.5f);
        LeanTween.alphaCanvas(OpaquePanel.GetComponent<CanvasGroup>(), 1, 0.3f);
        OpaquePanel.SetActive(true);
        dr.GetComponent<AudioSource>().PlayOneShot(dr.obook);
        dr.counter = 1;
    }

    public IEnumerator LinearQuest()
    {
        while (dr.counter == 0) yield return new WaitForSeconds(1f);
        //Mision 0 tutorial
        LeanTween.alphaCanvas(animCanvas1.GetComponent<CanvasGroup>(), 0f, 1f).setDelay(1f).setLoopPingPong().setRepeat(10);
        yield return new WaitForSeconds(5f);
        LeanTween.alphaCanvas(animCanvas2.GetComponent<CanvasGroup>(), 0f, 1f).setDelay(1f).setLoopPingPong().setRepeat(10);
        while (gs.Stat.Tutorial != 3) yield return new WaitForSeconds(1);
        if (!dr.open) dr.displayDiary(dr.open);
        //ticket
        isOnAnimation = true; // disable InputHandler
        int id = LeanTween.alphaCanvas(Ticket, 1f, 0.6f).id;
        while (LeanTween.isTweening(id) == true) yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(Ticket, 0f, 0.2f).setDelay(0.4f);
        //Mision 0 Tutorial Panel 2
        LeanTween.alphaCanvas(M0Tutorial.GetComponent<CanvasGroup>(), 0f, 0.2f).setDelay(0.2f);
        LeanTween.alphaCanvas(M0TutorialP2.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(0.2f);
        isOnAnimation = false; // enable InputHandler
        LeanTween.alphaCanvas(animCanvas3.GetComponent<CanvasGroup>(), 0f, 1f).setDelay(1f).setLoopPingPong().setRepeat(10);
        while (gs.Stat.Tutorial != 4) yield return new WaitForSeconds(1);
        if (!dr.open) dr.displayDiary(dr.open);
        //ticket
        isOnAnimation = true; // disable InputHandler
        id = LeanTween.alphaCanvas(Ticket, 1f, 0.6f).id;
        while (LeanTween.isTweening(id) == true) yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(Ticket, 0f, 0.2f).setDelay(0.4f);
        //Mision 1, Fixing
        LeanTween.alphaCanvas(M0TutorialP2.GetComponent<CanvasGroup>(), 0f, 0.2f).setDelay(0.2f);
        LeanTween.alphaCanvas(M1Fixing.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(1f);
        isOnAnimation = false; // enable InputHandler
        gs.Stat.overall = 2;
        while (gs.Stat.Fixing != 3) yield return new WaitForSeconds(1);
        if (!dr.open) dr.displayDiary(dr.open);
        //ticket
        isOnAnimation = true; // disable InputHandler
        id = LeanTween.alphaCanvas(Ticket, 1f, 0.6f).id;
        while (LeanTween.isTweening(id) == true) yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(Ticket, 0f, 0.2f).setDelay(0.4f);
        //Mision 1, Cooking
        LeanTween.alphaCanvas(M1Fixing.GetComponent<CanvasGroup>(), 0f, 0.2f).setDelay(0.2f);
        LeanTween.alphaCanvas(M2Cooking.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(1f);
        isOnAnimation = false;
        while (gs.Stat.Cocinar != 3) yield return new WaitForSeconds(1f);
        if (!dr.open) dr.displayDiary(dr.open);
        //ticket
        isOnAnimation = true; // disable InputHandler
        id = LeanTween.alphaCanvas(Ticket, 1f, 0.6f).id;
        while (LeanTween.isTweening(id) == true) yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(Ticket, 0f, 0.2f).setDelay(0.4f);
        LeanTween.alphaCanvas(M2Cooking.GetComponent<CanvasGroup>(), 0f, 0.2f).setDelay(0.2f);
        LeanTween.alphaCanvas(M3Bath.GetComponent<CanvasGroup>(), 1f, 1f).setDelay(1f);
        isOnAnimation = false; // disable InputHandler
    }

    public void displayDarkPanel(bool darkP)
    {
        switch (darkP)
        {
            case true:
                DarkPanel.SetActive(true);
                LeanTween.alphaCanvas(DarkPanel.GetComponent<CanvasGroup>(), 1, 0.5f);
                break;
            case false:

                LeanTween.alphaCanvas(DarkPanel.GetComponent<CanvasGroup>(), 0, 0.5f).setOnComplete(() => { DarkPanel.SetActive(false); });
                break;
        }
    }
}
