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
    [Header("DropdownMenú")]
    public Dropdown playersDrops;

    void Start () {
        DataBaseHandler db = DataBaseHandler.Instance;
        GlobalPanelHandler ph = GlobalPanelHandler.Instance;

        aceptNewUser.onClick.AddListener(() =>
        {
            int x = int.Parse(age.text);
            db.CreateNewPlayer(nick.text, nombre.text, lname.text, x, correo.text);
            nick.text = "";
            nombre.text = "";
            lname.text = "";
            age.text = "";
            correo.text = "";
            ph.PanelShowOff();
            db.UpdatePlayersDropdown(playersDrops);
        });

        cancelNewUser.onClick.AddListener(() =>
        {
            ph.PanelShowOff();
            nick.text = "";
            nombre.text = "";
            lname.text = "";
            age.text = "";
            correo.text = "";
        });
	}
	
}
