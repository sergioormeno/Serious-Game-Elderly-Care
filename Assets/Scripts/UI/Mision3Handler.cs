using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Mision3Handler : MonoBehaviour
{
    public Text Subtitulo;
    [Header("Botones primer plato")]
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    [Header("Botones ensaladas")]
    public Button b11;
    public Button b22;
    public Button b33;
    public Button b44;
    [Header("Botones bebidas")]
    public Button b111;
    public Button b222;
    public Button b333;
    public Button b444;
    private Text accion;
    [Header("Paneles")]
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;


    void Start()
    {
        b1.onClick.AddListener(() => buttonFunctionPanel1(b1));
        b2.onClick.AddListener(() => buttonFunctionPanel1(b2));
        b3.onClick.AddListener(() => buttonFunctionPanel1(b3));
        b4.onClick.AddListener(() => buttonFunctionPanel1(b4));
        b11.onClick.AddListener(() => buttonFunctionPanel2(b11));
        b22.onClick.AddListener(() => buttonFunctionPanel2(b22));
        b33.onClick.AddListener(() => buttonFunctionPanel2(b33));
        b44.onClick.AddListener(() => buttonFunctionPanel2(b44));
        b111.onClick.AddListener(() => buttonFunctionPanel3(b111));
        b222.onClick.AddListener(() => buttonFunctionPanel3(b222));
        b333.onClick.AddListener(() => buttonFunctionPanel3(b333));
        b444.onClick.AddListener(() => buttonFunctionPanel3(b444));
    }

    private void buttonFunctionPanel1(Button b)
    {
        GameStatus.Instance.playerActions.Actions = "Ha seleccionado" + b.GetComponentInChildren<Text>().text + " como plato principal";
        LeanTween.alphaCanvas(p1.GetComponent<CanvasGroup>(), 0, 0.25f);
        p1.SetActive(false);
        p2.SetActive(true);
        LeanTween.alphaCanvas(p2.GetComponent<CanvasGroup>(), 1, 0.45f);
    }

    private void buttonFunctionPanel2(Button b)
    {
        GameStatus.Instance.playerActions.Actions = "Ha seleccionado" + b.GetComponentInChildren<Text>().text + " como ensalada";
        LeanTween.alphaCanvas(p2.GetComponent<CanvasGroup>(), 0, 0.25f);
        p2.SetActive(false);
        p3.SetActive(true);
        LeanTween.alphaCanvas(p3.GetComponent<CanvasGroup>(), 1, 0.45f);
    }

    private void buttonFunctionPanel3(Button b)
    {
        GameStatus.Instance.playerActions.Actions = "Ha seleccionado" + b.GetComponentInChildren<Text>().text + " como liquido";
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0, 0.4f).setOnComplete(() => {
            closeMisionPanel();
        });
    }

    void closeMisionPanel()
    {
        gameObject.SetActive(false);
        CameraHandler.Instance.FirstPersonMode = true;
        GameStatus.Instance.Stat.Cocinar = 1;
    }

}
