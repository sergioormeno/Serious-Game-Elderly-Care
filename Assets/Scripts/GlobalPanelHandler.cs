using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class GlobalPanelHandler : ElSingleton<GlobalPanelHandler>
{

    public GameObject[] ActivePanel;

    public int interfaceDepth = 0;
    static bool _onceCaled = false;
    private GameObject auxO;

    public void Start()
    {
        ActivePanel = new GameObject[5];
    }


    public void HoverShowUp(GameObject HoverPanel)
    {
       
        HoverPanel.SetActive(true);
        LeanTween.alphaCanvas(HoverPanel.GetComponent<CanvasGroup>(), 1f, 0.3f);
    }

    public void PanelShowUp(GameObject Panel)
    {
        switch (interfaceDepth)
        {
            case 0:
                Panel.SetActive(true);
                LeanTween.alphaCanvas(Panel.GetComponent<CanvasGroup>(), 1f, 0.3f);
                interfaceDepth = 1;
                SetActivePanel(Panel);
                               
                break;
            default:
                auxO = GetActivePanel();
                auxO.SetActive(false);
                LeanTween.alphaCanvas(auxO.GetComponent<CanvasGroup>(), 0f, 0.3f);
                Panel.SetActive(true);
                LeanTween.alphaCanvas(Panel.GetComponent<CanvasGroup>(), 1f, 0.3f);
                interfaceDepth = interfaceDepth + 1;   
                SetActivePanel(Panel);
                            
                break;
        }

    }

    /// <summary>
    /// Esconde el Panel Actual
    /// </summary>
    public void PanelShowOff()
    {
        GameObject obj;
        if (interfaceDepth > 1)
        {
            obj = GetActivePanel();
            LeanTween.alphaCanvas(obj.GetComponent<CanvasGroup>(), 0f, 0.2f);
            obj.SetActive(false);
            ActivePanel[interfaceDepth] = null;
            ShowUpLastPanel();
            interfaceDepth = interfaceDepth - 1;
            
            
        }else
        {
            obj = GetActivePanel();
            LeanTween.alphaCanvas(obj.GetComponent<CanvasGroup>(), 0f, 0.2f);
            obj.SetActive(false);
            interfaceDepth = interfaceDepth - 1;
        }
    }

    /// <summary>
    /// Trae a la Pantalla el Último Panel.
    /// </summary>
    public void ShowUpLastPanel()
    {
        
        if (interfaceDepth >= 1)
        {
            GameObject obj = GetLastActivePanel();
            obj.SetActive(true);
            LeanTween.alphaCanvas(obj.GetComponent<CanvasGroup>(), 1f, 0.2f);

        }
       
    }

    /// <summary>
    /// Hace invisible el HoverPanel en caso de que la profundidad de ventanas abiertas sea 1.
    /// </summary>
    /// <param name="HoverPanel"></param>
    public void HoverShowOff(GameObject HoverPanel)
    {
        if (interfaceDepth == 1)
        {
            HoverPanel.SetActive(false);
            LeanTween.alphaCanvas(HoverPanel.GetComponent<CanvasGroup>(), 0f, 0.2f);
        }
    }

    /// <summary>
    /// Asigna el panel activo.
    /// </summary>
    /// <param name="obj"></param>
    public void SetActivePanel(GameObject obj)
    {
        ActivePanel[interfaceDepth] = obj;
    }

    /// <summary>
    /// Retorna el panel activo con respecto a la profundidad de la interfaz. 
    /// </summary>
    /// <returns></returns>
    public GameObject GetActivePanel()
    {
        return ActivePanel[interfaceDepth];

    }

    public GameObject GetLastActivePanel()
    {
        int aux = interfaceDepth - 1;
        return ActivePanel[aux];

    }

    /// <summary>
    /// Vuelve a su estado inicial todos los valores del script GlobalPanelHandler.
    /// </summary>
    public void ResetValues()
    {
        for (int i = 0; i < interfaceDepth; i++)
        {
            ActivePanel[i] = null;
        }
        interfaceDepth = 0;

    }



    void Awake()
    {
        if (!_onceCaled)
        {
            DontDestroyOnLoad(gameObject);
            _onceCaled = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
