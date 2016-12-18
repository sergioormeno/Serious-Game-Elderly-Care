using UnityEngine;

public class Winston : MonoBehaviour
{
    public GameStatus gs;
    public int hungry = 0;
    public int dirty = 0;
    public PanelHandler ph;
    public WinstonStats ws;


    public void Interact()
    {

        if (gs.Stat.Cocinar == 2)
        {
            Debug.Log("Haz alimentado a Winston");
            if (WinstonStats.Instance.myProp.estomago == 0)
            {
                WinstonStats.Instance.myProp.estomago = 100;
                StartCoroutine(ws.hungerControl());

            }
            else
            {
                WinstonStats.Instance.myProp.estomago = WinstonStats.Instance.myProp.estomago + (100 - WinstonStats.Instance.myProp.estomago);
            }
            gs.Stat.Cocinar = 3;
            hungry = 0;

        }

        if (gs.Stat.Duchar == 1)
        {
            Debug.Log("Estas cargando a winston, puedes llevarlo a la tina");
            gs.Stat.Duchar = 2;

        }

        //if (gs.Stat.medicina == 2)
        //{
        //    Debug.Log("Le haz dado la medicina a Winston");
        //    gs.Stat.medicina = 3;
        //}
        //else
        //{
        //    if (gs.Stat.medicina == 1)
        //    {
        //        Debug.Log("Recuerda darle su medicamento con un vaso de agua, anda al refrigerador por uno");
        //    }

        //}



    }





}
