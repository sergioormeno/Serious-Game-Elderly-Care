using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Toolbox : MonoBehaviour
{
    public Material material;
    public Material material2;
    public InputHandler handler;
    private Renderer rend;
    public AudioClip pick, drop;
    private AudioSource src;


    void Start()
    {
        rend = GetComponent<Renderer>();
        src = GetComponent<AudioSource>();
    }

    void Install()
    {
        rend.material = material2;
        src.PlayOneShot(drop);
        handler.hempty = true;
        if (DiaryPanelHandler.Instance.tf2.isOn == true)
        {
            GameStatus.Instance.Stat.Fixing = 3;
        }

    }

    void Interact()
    {
        if (!GameStatus.Instance.bar1 || !GameStatus.Instance.bar2)
        {
            rend.material = material;
            src.PlayOneShot(pick);
            handler.hempty = false;
            GameStatus.Instance.Stat.Fixing = 1;
        }
        else
        {
            Debug.Log("Ya haz instalado las barras");

        }
    }
}
