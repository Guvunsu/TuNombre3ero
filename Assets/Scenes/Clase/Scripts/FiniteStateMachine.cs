//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using static UnityEditor.VersionControl.Asset;

//public class FiniteStateMachine : MonoBehaviour {

//    public enum state {
//        IDLE_UP,
//        IDLE_DOWN,
//        IDLE_LEFT,
//        IDLE_RIGHT,
//        MOVING_UP,
//        MOVING_DOWN,
//        MOVING_LEFT,
//        MOVING_RIGHT,
//        /*
//                        PATTROLLING = 1,
//        PERSECUTING ejemplo , es mejor hacer todo en una maquina de estado 
//                       */
//    }
//    //public class FiniteStateMachineState : MonoBehaviour {
//    //    #region

//    //}

//    public state myState;

//    protected bool IsInIdleState {
//        get {
//            return (myState == state.IDLE_UP
//                || myState == state.IDLE_DOWN
//                || myState == state.IDLE_LEFT
//                || myState == state.IDLE_RIGHT);
//        }
//    }
//    void isInIdleState() {

//    }

//    void Start() {

//    }


//    void Update() {
//        Debug.Log(gameObject.name + " FiniteStateMachine - Update(): is in any Idle state " + IsInIdleState);
//        //Debug.Log(gameObject.name + "Finite State - Update(): we will move to " + value.ToString() + " state:0");
//        switch (myState) {
//            case state.IDLE_UP:
//            case state.IDLE_DOWN:
//            case state.IDLE_LEFT:
//            case state.IDLE_RIGHT:
//                isInIdleState();
//                break;
//            case state.MOVING_UP:
//            case state.MOVING_DOWN:
//            case state.MOVING_LEFT:
//            case state.MOVING_RIGHT:
//                MovingState();
//                break;
//        }

//    }
//    protected void MovingState() {

//    }

//    public state SetState {
//        set {
//            Debug.Log(gameObject.name + "Finite State - SetUpdate(): we will move to " + value.ToString() + " state:0");
//            myState = value;

//        }
//    }
//    protected void idleState() {
//        if (Input.GetKeyDown(KeyCode.W)) {
//            //SetState = state.MOVING
//        }
//    }
//    protected Vector2 _movementInputVector;
//    protected void handleMovement(InputAction.CallBackContext value) {
//        _movementInputVector = value.ReadValue<Vector2>();
//    }
//    // we recieve the event similar to  getbuttondown(),which means
//    //we recieve the very first moment of the input 
//    protected void handleAttack(InputAction.CallBackContext value) {

//    }
//}
