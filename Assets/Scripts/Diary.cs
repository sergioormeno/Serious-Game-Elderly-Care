using UnityEngine;
using System.Collections;


public class Diary : ElSingleton<Diary>
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject OpaquePanel;
    public bool open = false;
    public int counter = 0;
    public AudioClip obook;
    public AudioClip cbook;
    private AudioSource src;

    private RectTransform DiaryRect;
    private RectTransform SmallDiaryRect;
    private CanvasGroup oPanel;
    bool calledOneTimes=false;
    int called = 0;



    void Awake()
    {
        src = GetComponent<AudioSource>();
        DiaryRect = Panel1.GetComponent<RectTransform>();
        SmallDiaryRect = Panel2.GetComponent<RectTransform>();
        oPanel = OpaquePanel.GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (counter >= 1)
        {
            if (!src.isPlaying)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    displayDiary(open);
                }
            }
        }
    }

    public void displayDiary(bool openvalue)
    {
        switch (openvalue)
        {
            case true:
                LeanTween.moveX(DiaryRect, 200f, 0.15f);
                LeanTween.moveX(SmallDiaryRect, -60.8f, 0.15f);
                open = false;
                counter = counter + 1;
                src.PlayOneShot(cbook);
                displayOpaqueHelp(openvalue);
                break;

            case false:
                LeanTween.moveX(DiaryRect, -180f, 0.3f);
                LeanTween.moveX(SmallDiaryRect, 101f, 0.3f);
                open = true;
                src.PlayOneShot(obook);
                displayOpaqueHelp(openvalue);
                break;
        }
    }

    private void displayOpaqueHelp(bool dr2)
    {
        if (!calledOneTimes)
        {            
            switch (dr2)
            {
                case true:
                    called += 1;
                    if (called == 1) calledOneTimes = true;
                    LeanTween.alphaCanvas(oPanel, 0, 0.3f);
                    break;

                case false:
                    LeanTween.alphaCanvas(oPanel, 1, 0.3f);
                    break;
            }
            
        }
    }











}
