using UnityEngine;
using System.Collections;

public class Winston : ElSingleton<Winston>
{
    public int hungry = 0;
    public int dirty = 0;
    [Header("Sounds")]
    [HideInInspector]
    public AudioSource src;
    public AudioClip _eatingSound;
    public AudioClip sonidoSecar;
    public AudioClip sonidoZip;
    [Header("GameObjects Varios")]
    public GameObject PlatoLleno;
    public GameObject PlatoVacio;
    [HideInInspector]
    public bool sit = true, inPostoBath = false, takingBath = true;
    [Header("Polera y Short")]
    public GameObject shirtNormal;
    public GameObject shirtBlur;
    public GameObject shortNormal;
    public GameObject shortBlur;
    [Header("ShirtMaterials")]
    public Material shirtMaterialStandard;
    public Material shirtMaterialBlur;
    public Material shirtMaterialNaked;
    [Header("ShortMaterials")]
    public Material shortMaterialStandard;
    public Material shortMaterialBlur;
    public Material shortMaterialNaked;
    private Renderer shirtRend;
    private Renderer shortRend;
    [Header("Paneles de Misiones")]
    public GameObject Mision4AyudarWinston;
    private CanvasGroup M4CanvasGroup;


    //Referencias a otros componentes
    GameStatus gs;
    CameraHandler ch;
    DiaryPanelHandler dph;
    DiaryAnimation da;
    WinstonAnimator wa;
    WinstonStats ws;

    public bool TakingBath
    {
        get { return takingBath; }
        set
        {
            takingBath = value;
            switch (takingBath)
            {
                case true:
                    shortRend.material = shortMaterialNaked;
                    shortBlur.SetActive(true);
                    shirtRend.material = shirtMaterialNaked;
                    shirtBlur.SetActive(true);
                    break;
                case false:
                    shortRend.material = shortMaterialStandard;
                    shortBlur.SetActive(false);
                    shirtRend.material = shirtMaterialStandard;
                    shirtBlur.SetActive(false);
                    break;
            }
        }
    }

    void Start()
    {
        src = GetComponent<AudioSource>();
        shirtRend = shirtNormal.GetComponent<Renderer>();
        shortRend = shortNormal.GetComponent<Renderer>();
        M4CanvasGroup = Mision4AyudarWinston.GetComponent<CanvasGroup>();

        ws = WinstonStats.Instance;
        wa = WinstonAnimator.Instance;
        dph = DiaryPanelHandler.Instance;
        gs = GameStatus.Instance;
        ch = CameraHandler.Instance;
        da = DiaryAnimation.Instance;
    }

    public void Interact()
    {
        if (gs.Stat.Cocinar == 2)
        {
            StartCoroutine(WinstonIsEating());

            gs.Stat.Cocinar = 3;
            hungry = 0;
        }
    }

    void Update()
    {
    }


    public void Help()
    {
        if (sit)
        {
            if (gs.Stat.Tutorial == 3)
            {
                wa.Stand();
                gs.Stat.Tutorial = 4;
            }

            if (gs.Stat.Duchar == 1)
            {
                wa.Stand();
                StartCoroutine(wa.GotoBathroom());
                gs.playerActions.Actions = "El jugador ayudó a Winston a levantarse y a llegar a la ducha";
            }

        }
        else
        {
            switch (gs.Stat.Duchar)
            {
                case 1:
                    gs.playerActions.Actions = "El jugador ayudo a llegar a la ducha a Winston";
                    StartCoroutine(wa.GotoBathroom());
                    break;
                case 2:
                    displayMisionPanel();
                    gs.playerActions.Actions = "Para ayudar a Winston a entrar a la ducha, el orden de acciones que toma son:";
                    break;
                case 4:
                    StartCoroutine(wa.HelpWinstonLeaveBath());
                    break;
                case 5:
                    StartCoroutine(secarWinston());
                    break;
            }
        }


    }




    public IEnumerator WinstonIsEating()
    {
        PlatoLleno.SetActive(true);
        yield return new WaitForSeconds(2f);
        dph.IsDarkPanelActive = true;
        src.PlayOneShot(_eatingSound);
        yield return new WaitForSeconds(4f);
        src.Stop();
        ws.myProp.estomago = 100;
        if (ws.myProp.estomago == 0)
        {
            StartCoroutine(ws.sacietyControl());
        }
        PlatoLleno.SetActive(false);
        PlatoVacio.GetComponent<MeshRenderer>().enabled = true;
        dph.IsDarkPanelActive = false;
    }


    public void displayMisionPanel()
    {
        if (da.open) da.displayDiary(da.open);
        Mision4AyudarWinston.SetActive(true);
        ch.FirstPersonMode = false;
        LeanTween.alphaCanvas(M4CanvasGroup, 1, 0.3f);
    }

    public IEnumerator secarWinston()
    {
        dph.displayDarkPanel(true);
        src.PlayOneShot(sonidoSecar);
        while (src.isPlaying) yield return new WaitForSeconds(1f);
        src.PlayOneShot(sonidoZip);
        while (src.isPlaying) yield return new WaitForSeconds(1f);
        TakingBath = false;
        dph.displayDarkPanel(false);
        gs.Stat.Duchar = 6;
    }


}
