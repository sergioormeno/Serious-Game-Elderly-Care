using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinstonStats : ElSingleton<WinstonStats>
{

    public Text hambreText;
    public Text higieneText;
    public Text socialText;
    public Text saludText;
    public Text vejigaText;
    public Winston wins;
    public bool conscious = true;

    GameStatus gs;

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
        gs = GameStatus.Instance;
    }


    void Awake()
    {
        StartCoroutine(sacietyControl());
        StartCoroutine(higControl());
        StartCoroutine(vejigaControl());
        //		StartCoroutine (saludControl ());
        wins = gameObject.GetComponent<Winston>();
    }

    public IEnumerator sacietyControl()
    {

        while (myProp.estomago > 0)
        {
            myProp.estomago = myProp.estomago - 1;
            hambreText.text = myProp.estomago.ToString(); //debug
            yield return new WaitForSeconds(2.5f);
        }
        gs.playerActions.Actions = "Winston se encuentra hambriento, el jugador no ha prestado atención a sus necesidades";
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
        gs.playerActions.Actions = "Winston se encuentra sucio, el jugador no ha  prestado atención a su higiene";
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
                gs.playerActions.Actions = "Winston se ha desmayado por el descuido del jugador";
                conscious = false;
                gs.endGame = true;
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
            yield return new WaitForSeconds(3f);
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
