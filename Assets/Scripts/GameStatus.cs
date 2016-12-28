using UnityEngine;
using System.Collections;

public class GameStatus : ElSingleton<GameStatus>
{
    static bool _onceCaled = false;
    [HideInInspector]
    public bool bar1 = false;
    [HideInInspector]
    public bool bar2 = false;
    [Header("Barras")]
    public GameObject FirstBar;
    public GameObject SecondBar;
    [Header("Triggers")]
    public GameObject ShowerMision1Trigger;
    public GameObject ShowerMision2Trigger;
    public GameObject PlayerCheckerM3Trigger;
    [Header("Colliders")]
    public BoxCollider showerCollider;

    public class Status
    {
        //back-end status;
        public int overall;
        private int tutorial;
        private int fixing;
        private int cocinar;
        private int duchar;


        public int Tutorial
        {
            get { return tutorial; }
            set
            {
                tutorial = value;
                switch (tutorial)
                {
                    case 1: break;
                    case 2: break;
                    case 3:
                        DiaryPanelHandler.Instance.tt1.isOn = true;
                        break;
                    case 4:
                        Instance.FirstBar.SetActive(true);
                        Instance.SecondBar.SetActive(true);
                        DiaryPanelHandler.Instance.tt2.isOn = true;
                        break;
                }

            }
        }

        public int Fixing
        {
            get { return fixing; }
            set
            {
                fixing = value;
                switch (fixing)
                {
                    case 1:
                        showDiaryInCase();
                        DiaryPanelHandler.Instance.tf1.isOn = true;
                        break;
                    case 2:
                        showDiaryInCase();
                        DiaryPanelHandler.Instance.tf2.isOn = true;
                        break;
                    case 3:
                        DiaryPanelHandler.Instance.tf3.isOn = true;
                        break;
                }
            }
        }

        public int Cocinar
        {
            get
            {
                return cocinar;
            }

            set
            {
                cocinar = value;
                switch (cocinar)
                {
                    case 1:
                        showDiaryInCase();
                        DiaryPanelHandler.Instance.tc1.isOn = true;
                        WinstonAnimator.Instance.StartCoroutine(WinstonAnimator.Instance.Sitting());
                        break;
                    case 2:
                        showDiaryInCase();
                        DiaryPanelHandler.Instance.tc2.isOn = true;
                        break;
                    case 3:
                        DiaryPanelHandler.Instance.tc3.isOn = true;
                        Instance.ShowerMision1Trigger.SetActive(true);
                        break;
                }
            }
        }

        public int Duchar
        {
            get
            {
                return duchar;
            }

            set
            {
                duchar = value;
                switch (duchar)
                {
                    case 1:
                        showDiaryInCase();
                        DiaryPanelHandler.Instance.tb1.isOn = true;
                        Instance.showerCollider.enabled = true;
                        Instance.ShowerMision2Trigger.SetActive(true);
                        break;
                    case 2:
                        break;
                    case 3:
                        showDiaryInCase();
                        Instance.PlayerCheckerM3Trigger.SetActive(true);
                        DiaryPanelHandler.Instance.tb2.isOn = true;

                        break;
                    case 4:
                        Instance.PlayerCheckerM3Trigger.SetActive(false);
                        showDiaryInCase();
                        DiaryPanelHandler.Instance.tb3.isOn = true;

                        break;
                    case 5:
                        break;
                    case 6:
                        showDiaryInCase();
                        DiaryPanelHandler.Instance.tb4.isOn = true;
                        break;
                    case 7:
                        break;

                }
            }
        }

        public Status(int ov, int tut, int fix, int coc, int duc)
        {
            overall = ov;
            Tutorial = tut;
            Fixing = fix;
            Cocinar = coc;
            Duchar = duc;
        }

        private void showDiaryInCase()
        {
            if (!DiaryAnimation.Instance.open) DiaryAnimation.Instance.displayDiary(DiaryAnimation.Instance.open);
        }
    }

    public class PlayerActions
    {
        string actions = "Las acciones del jugador han sido:";

        public string Actions
        {
            get { return actions; }
            set
            {
                actions = actions + "\n" + value;
            }
        }
    }

    public enum TypeOfAction
    {
        Tutorial,
        Fixing,
        Cocinar,
        Duchar,
        Lavaropa,
        Medicina,
        Toilet,
    }


    public Status Stat = new Status(1, 0, 0, 0, 0);
    public PlayerActions pActions = new PlayerActions();

    void Awake()
    {
        if (!_onceCaled)
        {
            DontDestroyOnLoad(gameObject);
            _onceCaled = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
