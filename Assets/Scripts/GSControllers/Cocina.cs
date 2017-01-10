using UnityEngine;
using System.Collections;

public class Cocina : MonoBehaviour
{
    public GameStatus gs;
    public GameObject FriedPan;
    public AudioClip FriedSound;
    public AudioSource src;
    public bool called = false;



    public void Interact()
    {
        if (gs.Stat.Cocinar == 1)
        {
            if (called == false) StartCoroutine(Cocinando());
            else Debug.Log("ya has cocinado");
        }
        else
        {
            Debug.Log("No haz seleccionado los ingredientes o ya has cocinado por hoy.");

        }

    }

    void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    public IEnumerator Cocinando()
    {
        called = true;
        FriedPan.SetActive(true);
        yield return new WaitForSeconds(1f);
        src.PlayOneShot(FriedSound);
        yield return new WaitForSeconds(15f);
        gs.Stat.Cocinar = 2;
        gs.playerActions.Actions = "Ha cocinado y preparado lo que ha seleccionado para darle a Winston";
        src.Stop();
        FriedPan.SetActive(false);
    }


}