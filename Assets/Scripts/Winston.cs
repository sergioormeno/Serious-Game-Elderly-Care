using UnityEngine;
using System.Collections;

public class Winston : ElSingleton<Winston>
{
    public GameStatus gs;
    public int hungry = 0;
    public int dirty = 0;
    public WinstonStats ws;
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
    public bool sit = true;
    [HideInInspector]
    public bool inPostoBath = false;
    [HideInInspector]
    private bool takingBath;
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

    public bool TakingBath
    {
        get{return takingBath;}
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
            if (GameStatus.Instance.Stat.Tutorial == 3)
            {
                WinstonAnimator.Instance.Stand();
                GameStatus.Instance.Stat.Tutorial = 4;
            }

            if (GameStatus.Instance.Stat.Duchar == 1)
            {
                WinstonAnimator.Instance.Stand();
                StartCoroutine(WinstonAnimator.Instance.GotoBathroom());
            }

        }
        else
        {
            Debug.Log("else");
            switch (GameStatus.Instance.Stat.Duchar)
            {
                case 1:
                    StartCoroutine(WinstonAnimator.Instance.GotoBathroom());
                    break;
                case 2:
                    displayMisionPanel();
                    GameStatus.Instance.pActions.Actions = "Para ayudar a Winston a entrar a la ducha, el orden de acciones que toma son:";
                    break;
                case 4:
                    StartCoroutine(WinstonAnimator.Instance.HelpWinstonLeaveBath());
                    Debug.Log("called help leave");
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
        DiaryPanelHandler.Instance.IsDarkPanelActive = true;
        src.PlayOneShot(_eatingSound);
        yield return new WaitForSeconds(4f);
        src.Stop();
        WinstonStats.Instance.myProp.estomago = 100;
        if (WinstonStats.Instance.myProp.estomago == 0)
        {
            StartCoroutine(ws.hungerControl());
        }
        PlatoLleno.SetActive(false);
        PlatoVacio.GetComponent<MeshRenderer>().enabled = true;
        DiaryPanelHandler.Instance.IsDarkPanelActive = false;
    }


    public void displayMisionPanel()
    {
        if (DiaryAnimation.Instance.open) DiaryAnimation.Instance.displayDiary(DiaryAnimation.Instance.open);
        Mision4AyudarWinston.SetActive(true);
        CameraHandler.Instance.FirstPersonMode = false;
        LeanTween.alphaCanvas(Mision4AyudarWinston.GetComponent<CanvasGroup>(), 1, 0.3f);
    }

    public IEnumerator secarWinston()
    {
        DiaryPanelHandler.Instance.displayDarkPanel(true);
        src.PlayOneShot(sonidoSecar);
        while (src.isPlaying) yield return new WaitForSeconds(1f);
        src.PlayOneShot(sonidoZip);
        while (src.isPlaying) yield return new WaitForSeconds(1f);
        TakingBath = false;
        DiaryPanelHandler.Instance.displayDarkPanel(false);
        GameStatus.Instance.Stat.Duchar = 6;
    }


}
