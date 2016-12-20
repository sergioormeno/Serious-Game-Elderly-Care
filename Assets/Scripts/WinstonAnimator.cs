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


    void Start()
    {
        animator = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();
    }

    void OnAnimatorMove()
    {
        agente.velocity = animator.deltaPosition / Time.deltaTime;
    }

    void Update()
    {
        animator.SetFloat("Speed", agente.velocity.magnitude);
    }

    public IEnumerator Sitting()
    {
        agente.destination = eatPos1.position;
        yield return new WaitForSeconds(1f);
        while (animator.GetFloat("Speed") != 0) yield return new WaitForSeconds(1f);
        agente.destination = eatPos2.position;
        yield return new WaitForSeconds(1f);
        while (animator.GetFloat("Speed") != 0) yield return new WaitForSeconds(1f);
        sitPosWhileEating();
        Sit();
    }

    public void sitPosWhileEating()
    {
        agente.transform.LookAt(platoDeComida);
    }

    public void Stand()
    {
        Winston.Instance.sit = false;
        animator.SetBool("sit", false);
    }

    public void Sit()
    {
        Winston.Instance.sit = true;
        animator.SetBool("sit", true);
    }

    public IEnumerator GotoBathroom()
    {
        if (!Winston.Instance.sit) yield return new WaitForSeconds(4.5f);
        agente.destination = showerPos1.position;
    }

    public IEnumerator HelpWinstonLeaveBath()
    {
        yield return new WaitForSeconds(2f);
        agente.destination = showerPos1.position;
        GameStatus.Instance.Stat.Duchar = 5;
    }

    public void EnterShower()
    {
        agente.destination = showerPos2.position;
        GameStatus.Instance.Stat.Duchar = 3;
    }
}
