using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class FiniteStateMachine : MonoBehaviour {

    public enum state {
        IDLE_UP,
        IDLE_DOWN,
        IDLE_LEFT,
        IDLE_RIGHT,
        MOVING_UP,
        MOVING_DOWN,
        MOVING_LEFT,
        MOVING_RIGHT,
        /*
                        PATTROLLING = 1,
        PERSECUTING ejemplo , es mejor hacer todo en una maquina de estado 
                       */
    }
    public class FiniteStateMachineState : MonoBehaviour {
        #region
# UnityMethods
# FiniteStateMachine

# LocalMethods
    }

    protected bool IsInIdleState {
        get {
            return (state == state.IDLE_UP
                || state == state.IDLE_DOWN
                || state == state.IDLE_LEFT
                || state == state.IDLE_RIGHT);
        }
    }
    void isInIdleState() {

    }
    #endregion
    void Start() {

    }


    void Update() {
        Debug.Log(gameObject.name + " FiniteStateMachine - Update(): is in any Idle state " + IsInIdleState);
        Debug.Log(gameObject.name + "Finite State - Update(): we will move to " + value.ToString() + " state:0");
            switch (state) {
            case States.IDLE_UP:
            case States.IDLE_DOWN:
            case States.IDLE_LEFT:
            case States.IDLE_RIGHT:
                isInIdleState();
                break;
            case States.MOVING_UP:
            case States.MOVING_DOWN:
            case States.MOVING_LEFT:
            case States.MOVING_RIGHT:
                MovingState();
                break;
        }

    }
    protected void MovingState() {

    }

    public States SetState {
        set {
            Debug.Log(gameObject.name + "Finite State - SetUpdate(): we will move to " + value.ToString() + " state:0");
            state = value;

        }
    }
    protected void idleState() {
        if (Input.GetKeyDown(KeyCode.W)) { 
            SetState = States.MOVING
        }
    }
}
