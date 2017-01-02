using UnityEngine;
using System.Collections;

public class Lavaplatos : MonoBehaviour {
	public GameStatus gs; 
    public AudioClip _washSound;
    public AudioSource src;
    public GameObject platoLimpio;


	public void Interact(){
		if (gs.Stat.Cocinar == 4) {
            StartCoroutine(lavarPlatos());
		} else {
            Debug.Log("No hay platos por lavar");
		}
	}

    public IEnumerator lavarPlatos()
    {
        src.PlayOneShot(_washSound);
        DiaryPanelHandler.Instance.IsDarkPanelActive = true;
        yield return new WaitForSeconds(1f);
        gs.Stat.Cocinar = 5;
        yield return new WaitForSeconds(3f);
        DiaryPanelHandler.Instance.IsDarkPanelActive = false;
        src.Stop();
        GameStatus.Instance.pActions.Actions = "Ha lavado la loza ocupada por Winston";
        platoLimpio.SetActive(true);
    }
}
