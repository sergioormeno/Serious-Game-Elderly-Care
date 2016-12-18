using UnityEngine;
using UnityEngine.UI;

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




    void Start()
    {
        aceptB.onClick.AddListener(() =>
        {
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0, 0.5f).setOnComplete(() =>
            {
                gameObject.SetActive(false);
            });
            CameraHandler.Instance.FirstPersonMode = true;
            GameStatus.Instance.Stat.Duchar = 1;
        });

        t1.onValueChanged.AddListener((b) => { g1.SetActive(true);});
        t2.onValueChanged.AddListener((b) => { g2.SetActive(true); });
        t3.onValueChanged.AddListener((b) => { g3.SetActive(true); });
        t4.onValueChanged.AddListener((b) => { g4.SetActive(true); });
        t5.onValueChanged.AddListener((b) => { g5.SetActive(true); });
        t6.onValueChanged.AddListener((b) => { g6.SetActive(true); });
        t7.onValueChanged.AddListener((b) => { g7.SetActive(true); });
        t8.onValueChanged.AddListener((b) => { g8.SetActive(true); });
    }

}
