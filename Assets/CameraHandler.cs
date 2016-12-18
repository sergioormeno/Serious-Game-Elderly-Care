using UnityEngine;
using Footsteps;

public class CameraHandler : ElSingleton<CameraHandler>
{

    public GameObject Jugador;
    bool firstPersonMode=true;
    CameraView camS;
    FirstPersonController fpC;
    CharacterFootsteps chF;
    InputHandler inH;
    

    public bool FirstPersonMode
    {
        get{return firstPersonMode;}

        set
        {
            firstPersonMode = value;
            controllerMode(firstPersonMode);
        }
    }

    public void controllerMode(bool b)
    {
        switch (b)
        {
            case false:
                fpC.enabled = false;
                camS.enabled = false;
                chF.enabled = false;
                inH.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                break;
            case true:
                fpC.enabled = true;
                camS.enabled = true;
                chF.enabled = true;
                inH.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                break;
           
        }
    }

    void Start()
    {
        chF = Jugador.GetComponent<CharacterFootsteps>();
        camS = Jugador.GetComponent<CameraView>();
        fpC = Jugador.GetComponent<FirstPersonController>();
        inH = Jugador.GetComponentInChildren<InputHandler>();
       
    }

}
