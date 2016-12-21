using UnityEngine;
using System.Collections;

public class PlatoALavar : MonoBehaviour
{
    AudioSource src;
    public AudioClip pickUpSound;

    public void Interact()
    {
        if(GameStatus.Instance.Stat.Cocinar == 3)
        {
            GameStatus.Instance.Stat.Cocinar = 4;
            src.PlayOneShot(pickUpSound);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
       
    }

    void Start()
    {
        src = GetComponent<AudioSource>();
    }
}
