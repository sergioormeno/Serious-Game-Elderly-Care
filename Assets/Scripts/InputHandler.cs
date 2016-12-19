using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    private int x;
    private int y;
    public bool hempty = true;
    private float timeStamp;
    private GameObject obj;

    public GameStatus gs;





    void Start()
    {
        x = Screen.width / 2;
        y = Screen.height / 2;
    }

    void Update()
    {
        // Acciones
        if (Input.GetMouseButton(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit rayCastHit;

            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + 1;
                if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
                {
                    obj = rayCastHit.collider.gameObject;
                    InteractHandler(gs.Stat.overall, obj);
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit rayCastHit;

            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + 1;
                if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
                {
                    obj = rayCastHit.collider.gameObject;
                    obj.SendMessage("Help", null, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }


    void InteractHandler(int x, GameObject gbAux)
    {
        switch (x)
        {
            case 2: //Fixing
                if (gbAux.tag == "Door")
                {
                    gbAux.SendMessage("Interact", 1f, SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    if (hempty == true)
                    {
                        gbAux.SendMessage("Interact", null, SendMessageOptions.DontRequireReceiver);
                    }
                    else
                    {
                        gbAux.SendMessage("Install", null, SendMessageOptions.DontRequireReceiver);
                    }

                }
                break;
            case 1: //Tutorial
                if (gbAux.tag == "door")
                {
                    gbAux.SendMessage("Interact", 1f, SendMessageOptions.DontRequireReceiver);
                }
                break;
            default:
                gbAux.SendMessage("Interact", null, SendMessageOptions.DontRequireReceiver);
                break;
        }
    }







}
