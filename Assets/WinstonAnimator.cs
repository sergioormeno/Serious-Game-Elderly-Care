using UnityEngine;
using System.Collections;

public class WinstonAnimator : ElSingleton<WinstonAnimator>
{
    NavMeshAgent _agent; 
    Animator _anim;
    public Transform eatPos1;
    public Transform eatPos2;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform platoDeComida;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();        
    }

    void OnAnimatorMove()
    {
        _agent.velocity = _anim.deltaPosition / Time.deltaTime;
    }    

    void Update()
    {
        _anim.SetFloat("Speed", _agent.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.P)) {
            StartCoroutine(Sitting());
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            _agent.destination = pos2.position;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            gameObject.transform.LookAt(platoDeComida);
            _anim.applyRootMotion = true;
            _anim.SetBool("eat", true);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _anim.SetBool("eat", false);
        }

    }

    public IEnumerator Sitting()
    {
        _agent.destination = eatPos2.position;
        yield return new WaitForSeconds(1f);
        while (_anim.GetFloat("Speed")!=0) yield return new WaitForSeconds(1f); ;
        sitPos();        
        _anim.SetBool("eat", true);
    }

    public void sitPos()
    {
        _agent.transform.LookAt(platoDeComida);
    }
}
