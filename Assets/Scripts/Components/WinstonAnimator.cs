using UnityEngine;
using System.Collections;

public class WinstonAnimator : ElSingleton<WinstonAnimator>
{
    NavMeshAgent agente;
    [HideInInspector]
    public Animator animator;
    public Transform eatPos1;
    public Transform eatPos2;
    public Transform showerPos1;
    public Transform showerPos2;
    public Transform kitchenPos1;
    public Transform bedPos1;
    public Transform platoDeComida;
    public bool readyToEat = false;
    public bool readyToShower = false;
    GameStatus gs;
    Winston w;


    void Start()
    {
        animator = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();
        gs = GameStatus.Instance;
        w = Winston.Instance;
    }

    void OnAnimatorMove()
    {
        agente.velocity = animator.deltaPosition / Time.deltaTime;
    }

    void Update()
    {
        animator.SetFloat("Speed", agente.velocity.magnitude);

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    StartCoroutine(Sitting());
        //}

        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    StartCoroutine(GotoBathroom());
        //}
    }

    public IEnumerator Sitting()
    {
        agente.destination = eatPos1.position;
        yield return new WaitForSeconds(1f);
        while (animator.GetFloat("Speed") != 0) yield return new WaitForSeconds(1f);
        agente.destination = eatPos2.position;
        while (!readyToEat) yield return new WaitForSeconds(1f);
        agente.Stop();
        while (animator.GetFloat("Speed") != 0) yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        sitPosWhileEating();
        Sit();
    }

    public void sitPosWhileEating()
    {
        agente.Stop();
        agente.transform.LookAt(platoDeComida);
    }

    public void Stand()
    {
        w.sit = false;
        animator.SetBool("sit", false);
    }

    public void Sit()
    {
        w.sit = true;
        animator.SetBool("sit", true);
    }

    public IEnumerator GotoBathroom()
    {
        yield return new WaitForSeconds(6);
        agente.ResetPath();
        agente.destination = showerPos1.position;
        while (!readyToShower) yield return new WaitForSeconds(1f);
        agente.Stop();
        while (animator.GetFloat("Speed") != 0) yield return new WaitForSeconds(1f);

    }

    public IEnumerator HelpWinstonLeaveBath()
    {
        yield return new WaitForSeconds(1f);
        agente.ResetPath();
        agente.destination = showerPos1.position;
        gs.Stat.Duchar = 5;
        if (!gs.towelonChooseItems) gs.endGame = true;
        yield return new WaitForSeconds(1f);

    }

    public void EnterShower()
    {
        agente.ResetPath();
        agente.destination = showerPos2.position;
        gs.Stat.Duchar = 3;
    }

    public void StopAgent()
    {
        agente.Stop();
    }

    public void ResetAgentPath()
    {
        agente.ResetPath();
    }
}