using SotomaYorch.DungeonCrawler;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.VersionControl.Asset;

public class FSM : MonoBehaviour
{
    public agentFSM fsm;
    //public Transform playerAgent;
    #region References

    [SerializeField, HideInInspector] protected Animator _animator;
    [SerializeField, HideInInspector] protected Rigidbody2D _rigidbody;
    [SerializeField] protected Agent _agent;

    #endregion

    #region RuntimeVariables

    [SerializeField] protected States _state;
    [SerializeField] protected Vector2 _movementDirection;
    [SerializeField] protected float _movementSpeed;

    #endregion
    Animator animator;
    public enum agentFSM
    {
        //IDLE
        IDLE_DOWN,
        IDLE_UP,
        IDLE_RIGHT,
        IDLE_LEFT,
        //MOVING
        MOVING_DOWN,
        MOVING_UP,
        MOVING_RIGHT,
        MOVING_LEFT,
        //ATTACKING
        ATTACKING_UP,
        ATTACKING_DOWN,
        ATTACKING_LEFT,
        ATTACKING_RIGHT,
        //SPRINTING
        SPRINT_DOWN,
        SPRINT_UP,
        SPRINT_RIGHT,
        SPRINT_LEFT,
        //carring
        CARRY_DOWN,
        CARRY_UP,
        CARRY_RIGHT,
        CARRY_LEFT,
        //dying
        DEATH
    }
    public enum agentEnemy
    {
        //STOP
        STOP,
        //MOVE
        MOVE_UP,
        MOVE_DOWN,
        MOVE_LEFT,
        MOVE_RIGHT,
        //ATTACK
        ATTACK,
        DIE //TODO: Complete the code to administate this new state
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {

    }
    private void OnDrawGizmos()
    {
        initializedStatesAgent();
    }
    public void initializedStatesAgent()
    {
        switch (fsm)
        {

            case agentFSM.IDLE_DOWN:
            case agentFSM.IDLE_UP:
            case agentFSM.IDLE_RIGHT:
            case agentFSM.IDLE_LEFT:
                Move();
                break;

            case agentFSM.MOVING_DOWN:
            case agentFSM.MOVING_UP:
            case agentFSM.MOVING_RIGHT:
            case agentFSM.MOVING_LEFT:
                Move();
                break;

            case agentFSM.ATTACKING_DOWN:
            case agentFSM.ATTACKING_UP:
            case agentFSM.ATTACKING_RIGHT:
            case agentFSM.ATTACKING_LEFT:
                Attack();
                break;

            case agentFSM.SPRINT_DOWN:
            case agentFSM.SPRINT_UP:
            case agentFSM.SPRINT_RIGHT:
            case agentFSM.SPRINT_LEFT:
                Sprint();
                break;

            case agentFSM.CARRY_DOWN:
            case agentFSM.CARRY_UP:
            case agentFSM.CARRY_RIGHT:
            case agentFSM.CARRY_LEFT:
                Carry();
                break;

            case agentFSM.DEATH:
                Death();
                break;
        }
    }
    protected void InitializeFiniteStateMachine()
    {
        if (_agent == null)
        {
            _agent = GetComponent<Agent>();
        }
    }

    protected void CleanAnimatorFlags()
    {
        foreach (agentEnemy stateMechanic in Enum.GetValues(typeof(agentEnemy)))
        {
            _animator.SetBool(stateMechanic.ToString(), false);
        }
    }
    public void Idle()
    {
        animator.SetBool("STOP", true);
        animator.SetBool("MOVE_UP", false);
        animator.SetBool("MOVE_DOWN", false);
        animator.SetBool("MOVE_LEFT", false);
        animator.SetBool("MOVE_RIGHT", false);
    }
    public void Move()
    {
        //animator.SetBool("STOP", false);
        animator.SetBool("MOVe_UP", fsm == agentFSM.MOVING_UP);
        animator.SetBool("MOVE_DOWN", fsm == agentFSM.MOVING_DOWN);
        animator.SetBool("MOVE_LEFT", fsm == agentFSM.MOVING_LEFT);
        animator.SetBool("MOVE_RIGHT", fsm == agentFSM.MOVING_RIGHT);

        // Muevoel mono en la dirección que quiero
        Vector3 direction = Vector3.zero;

        if (fsm == agentFSM.MOVING_UP) direction = Vector3.up;
        else if (fsm == agentFSM.MOVING_DOWN) direction = Vector3.down;
        else if (fsm == agentFSM.MOVING_LEFT) direction = Vector3.left;
        else if (fsm == agentFSM.MOVING_RIGHT) direction = Vector3.right;

        transform.position += direction * Time.deltaTime * 3;// a ver si con 3 es suficiente, si no le aumento o resto
    }

    public void Attack()
    {
        animator.SetBool("STOP", true);
        //animator.SetBool("MOVING_UP",fsm == agentFSM.ATTACKING_UP);
        // PREGUNTAR SI ESTO ESTO ES FACTIBLE 
        //preguntar al profe como debo incluir el hitbox,chance solo la llamo por referencia script< >()
    }
    public void Sprint()
    {
        animator.SetBool("STOP", false);
        //animator.SetBool("STOP",fsm);
        animator.SetBool("MOVING_UP", fsm == agentFSM.SPRINT_UP);
        animator.SetBool("MOVING_DOWN", fsm == agentFSM.SPRINT_DOWN);
        animator.SetBool("MOVING_LEFT", fsm == agentFSM.SPRINT_LEFT);
        animator.SetBool("MOVING_RIGHT", fsm == agentFSM.SPRINT_RIGHT);


        Vector3 direction = Vector3.zero;

        if (fsm == agentFSM.SPRINT_UP) direction = Vector3.up;
        else if (fsm == agentFSM.SPRINT_DOWN) direction = Vector3.down;
        else if (fsm == agentFSM.SPRINT_LEFT) direction = Vector3.left;
        else if (fsm == agentFSM.SPRINT_RIGHT) direction = Vector3.right;

        transform.position += direction * Time.deltaTime * 6; //si le subo al move le saco el doble a este
    }
    public void Carry()
    {
        animator.SetBool("Stop", true);
        //poner logica de cargar el objeto igual con una condicional if e input 
        // pregunta si se puede usar el system input para esto 
    }
    public void Death()
    {
        animator.SetBool("Stop", true);
        // activar el panel de muerte 
        //  SceneManager.SetActiveScene("PanelPausa");
        this.enabled = false; // Detiene el script.
    }
    private void ResetAnimatorParameters()
    {
        //ME AYUDA PARA BORRAR LAS ANIMACIONES DESPUES D EUNA EJECUCION 
        //ASI NO HAY PROBLEMAS DE QUE LA WEA QUIERA MOSTRARME MAS DE 2 ANIMACIONES CUANDO EL USUARIO
        // ESTE USANDO DIFERENTES INPUTS QUE REQUIERA CADA UNA, 1 ANIMACION
        animator.SetBool("Stop", false);
        animator.SetBool("Move_Up", false);
        animator.SetBool("Move_Down", false);
        animator.SetBool("Move_Left", false);
        animator.SetBool("Move_Right", false);
    }
    public void ChangeState(agentFSM newAgentState)
    {
        ResetAnimatorParameters();
        fsm = newAgentState; // Actualiza el estado actual de la FSM.
        initializedStatesAgent();
        // Ejecuta la lógica específica del nuevo estado.
        //ponerlo en mi update
    }

    #region PublicMethods

    //Action
    public void StateMechanic(agentEnemy value)
    {
        _animator.SetBool(value.ToString(), true);
    }

    public void SetState(States value)
    {
        CleanAnimatorFlags();
        _state = value;
        //TODO: Pending to develop
        initializedStatesAgent();
    }

    #endregion
    #region GettersSetters

    public Vector2 GetMovementDirection
    {
        get { return _movementDirection; }
    }

    public Vector2 SetMovementDirection
    {
        set { _movementDirection = value; }
    }

    public float SetMovementSpeed
    {
        set { _movementSpeed = value; }
    }

    #endregion
}

