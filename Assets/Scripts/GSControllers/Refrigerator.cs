using UnityEngine;
using System.Collections;

public class Refrigerator : MonoBehaviour {
    public GameObject Mision3Panel;
    public AudioClip OpenFridge;
    public AudioClip CloseFridge;
    public AudioSource src;

    GameStatus gs;
    CameraHandler ch;
    DiaryAnimation da;

    public void Interact(){
		if (gs.Stat.Cocinar == 0) {
            if(gs.Stat.Fixing == 3 )
            {
                src.PlayOneShot(OpenFridge);
                displayMisionPanel();
            }
            Debug.Log ("Haz seleccionado los ingredientes");
		} else {
			if (gs.Stat.Cocinar == 1) {
				Debug.Log ("Ya haz seleccionado los ingredientes");			
			} else {
				Debug.Log ("Ya haz cocinado, alimenta a Winston o lava la losa en el lavaplatos.f"); 
			}
		}
	}

    void displayMisionPanel()
    {
        if (da.open) da.displayDiary(da.open);
        Mision3Panel.SetActive(true);
        ch.FirstPersonMode = false;
        LeanTween.alphaCanvas(Mision3Panel.GetComponent<CanvasGroup>(), 1, 0.3f);
        gs.playerActions.Actions = "El jugador va a elegir que darle de comer a Winston";

    }




    void Start()
    {
        src = GetComponent<AudioSource>();
        da = DiaryAnimation.Instance;
        gs = GameStatus.Instance;
        ch = CameraHandler.Instance;
    }




}
