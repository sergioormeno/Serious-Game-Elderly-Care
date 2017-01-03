using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class CreateNewUserPanel : MonoBehaviour {
    [Header("NewUser")]
    public Text nick;
    public Text nombre;
    public Text lname;
    public Text age;
    public Text correo;

    [Header("Botones")]
    public Button aceptNewUser;
    public Button cancelNewUser;

    void Start () {

        aceptNewUser.onClick.AddListener(() =>
        {
            int x = int.Parse(age.text);
            DataBaseHandler.Instance.CreateNewPlayer(nick.text, nombre.text, lname.text, x, correo.text);
            nick.text = "";
            nombre.text = "";
            lname.text = "";
            age.text = "";
            correo.text = "";
            GlobalPanelHandler.Instance.PanelShowOff();
        });

        cancelNewUser.onClick.AddListener(() =>
        {
            GlobalPanelHandler.Instance.PanelShowOff();
            nick.text = "";
            nombre.text = "";
            lname.text = "";
            age.text = "";
            correo.text = "";
        });
	}
	
}
