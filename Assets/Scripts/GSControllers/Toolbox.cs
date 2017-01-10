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

    GameStatus gs;


    void Start()
    {
        rend = GetComponent<Renderer>();
        src = GetComponent<AudioSource>();
        gs = GameStatus.Instance;
    }

    void Install()
    {
        rend.material = material2;
        src.PlayOneShot(drop);
        handler.hempty = true;
       gs.playerActions.Actions = "El jugador ha dejado las herramientas";
        if (gs.Stat.Fixing == 2) gs.Stat.Fixing = 3;
    }

    void Interact()
    {
        rend.material = material;
        src.PlayOneShot(pick);
        handler.hempty = false;
        gs.playerActions.Actions = "El jugador ha tomado las herramientas";
        if (gs.Stat.Fixing == 0) gs.Stat.Fixing = 1;

    }
}
