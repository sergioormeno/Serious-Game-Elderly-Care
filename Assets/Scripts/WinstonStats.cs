using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinstonStats : ElSingleton<WinstonStats>
{

    public GameStatus gs;
    public Text hambreText;
    public Text higieneText;
    public Text socialText;
    public Text saludText;
    public Text vejigaText;
    public Winston wins;
    public bool conscious = true;

    public class Propiedades
    {

        public int higiene;
        public int estomago;
        public int social;
        public int energia;
        public int salud;
        public int vejiga;

        public Propiedades(int hig, int ham, int soc, int energ, int sal, int vej)
        {

            higiene = hig;
            estomago = ham;
            social = soc;
            energia = energ;
            salud = sal;
            vejiga = vej;
        }
    }
    public Propiedades myProp = new Propiedades(60, 40, 80, 100, 100, 40);

    void Start()
    {
        hambreText.text = myProp.estomago.ToString();
        higieneText.text = myProp.higiene.ToString();
        saludText.text = myProp.salud.ToString();
        socialText.text = myProp.social.ToString();
        vejigaText.text = myProp.social.ToString();
    }


    void Awake()
    {
        StartCoroutine(hungerControl());
        StartCoroutine(higControl());
        StartCoroutine(vejigaControl());
        //		StartCoroutine (saludControl ());
        wins = gameObject.GetComponent<Winston>();
    }

    public IEnumerator hungerControl()
    {

        while (myProp.estomago > 0)
        {
            myProp.estomago = myProp.estomago - 1;
            hambreText.text = myProp.estomago.ToString(); //debug
            yield return new WaitForSeconds(1.5f);
        }
        GetComponent<Winston>().hungry = 1;

    }

    public IEnumerator higControl()
    {
        while (myProp.higiene > 0)
        {
            myProp.higiene = myProp.higiene - 1;
            higieneText.text = myProp.higiene.ToString();
            yield return new WaitForSeconds(1.5f);
        }
        wins.dirty = wins.dirty + 1;
    }

    public IEnumerator saludControl()
    {
        while (conscious == true)
        {
            myProp.salud = myProp.salud - (wins.dirty + wins.hungry);
            saludText.text = myProp.salud.ToString();
            if (myProp.salud < 0)
            {
                myProp.salud = 0;
                Debug.Log("winston se ha desmayado");
                conscious = false;
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator vejigaControl()
    {

        while (myProp.vejiga > 0)
        {
            myProp.vejiga = myProp.vejiga - 1;
            vejigaText.text = myProp.vejiga.ToString();
            yield return new WaitForSeconds(1f);
        }

        while (myProp.vejiga == 0)
        {
            myProp.vejiga = 100;
            myProp.higiene = 0;
            higieneText.text = myProp.higiene.ToString();
            vejigaText.text = myProp.vejiga.ToString();
            yield return new WaitForSeconds(1f);
        }
        wins.dirty = wins.dirty + 1;
        StartCoroutine(vejigaControl());

    }
}
