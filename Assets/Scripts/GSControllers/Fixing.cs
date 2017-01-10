using UnityEngine;
using System.Collections;

public class Fixing : MonoBehaviour
{
    public Material Material;
    public Material Material2;
    private AudioSource src;
    public AudioClip bb;
    private Renderer rend;



    void Start()
    {
        src = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
    }




    void Install()
    {
        if (GameStatus.Instance.bar1 == false)
        {
            src.PlayOneShot(bb, 1);
            rend.material = Material2;
            GameStatus.Instance.bar1 = true;
        }
        else
        {
            if (GameStatus.Instance.bar2 == false)
            {
                src.PlayOneShot(bb, 1);
                rend.material = Material2;
                GameStatus.Instance.bar2 = true;
                GameStatus.Instance.Stat.Fixing = 2;
                GameStatus.Instance.playerActions.Actions = "El jugador ha instalado las barras";
            }
        }
    }

}

