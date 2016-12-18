using UnityEngine;
using System.Collections;

public class ChooseItems : MonoBehaviour
{

    public GameObject ChooseItemsPanel;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            displayChoosePanel();
        }
    }

    public void displayChoosePanel()
    {
        if (Diary.Instance.open) Diary.Instance.displayDiary(Diary.Instance.open);
        ChooseItemsPanel.SetActive(true);
        LeanTween.alphaCanvas(ChooseItemsPanel.GetComponent<CanvasGroup>(), 1, 0.7f);
        CameraHandler.Instance.FirstPersonMode = false;
        DestroyObject(gameObject);
    }
}
