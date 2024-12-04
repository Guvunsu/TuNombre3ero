using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SotomaYorch.DungeonCrawler {
    #region Enums

    public enum States {
        //AgentPlayer
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
        //attacking
        ATTACKING_DOWN,
        ATTACKING_UP,
        ATTACKING_RIGHT,
        ATTACKING_LEFT,
        //SPRINT
        SPRINT_DOWN,
        SPRINT_UP,
        SPRINT_RIGHT,
        SPRINT_LEFT,
        //HURT ME :p
        HIT_DOWN,
        HIT_UP,
        HIT_RIGHT,
        HIT_LEFT,
        //DYING
        DYING_LEFT,
        DYING_RIGHT
    }

    public enum StateMechanics {
        //AGENTS ENEMIES
        //STOP
        STOP,
        //MOVE
        MOVE_UP,
        MOVE_DOWN,
        MOVE_LEFT,
        MOVE_RIGHT,
        //DYING
        DYING_LEFT,
        DYING_RIGHT
    }

    #endregion

    #region Structs


    #endregion

    public class FiniteStateMachine : MonoBehaviour {
        #region Knobs


        #endregion

        #region References

        [SerializeField] protected Animator _animator;
        [SerializeField] protected Rigidbody2D _rigidbody;

        #endregion

        #region RuntimeVariables

        [SerializeField] protected States _state;
        [SerializeField] protected Vector2 _movementDirection;
        [SerializeField] protected float _movementSpeed;

        #endregion

        #region LocalMethods

        protected void InitializeFiniteStateMachine() {
            _state = States.IDLE_DOWN;
            _movementDirection = Vector2.zero;
            _movementDirection.x = 0;
            _movementDirection.y = 0;
            CleanAnimatorFlags();
        }

        protected void CleanAnimatorFlags() {
            foreach (StateMechanics stateMechanic in Enum.GetValues(typeof(StateMechanics))) {
                //LA DE ABAJO ME LA DIO CHATGPT
                // ME LA RECOMENDO PARA OPTIMIZAR
                //SIRVE PARA HACERME UN CHECK IN DE SEGURIDAD, PARA EVITAR 
                //CRUCES/PROBLEMAS CON PARAMETROS INEXITENTES
                if (_animator.parameters.Any(p => p.name == stateMechanic.ToString())) {
                    //LA DE ABAJO YA ES TUYA 
                    _animator.SetBool(stateMechanic.ToString(), false);
                }
            }
        }
        #endregion

        #region UnityMethods

        private void Start() {
            InitializeFiniteStateMachine();
        }

        private void FixedUpdate() {
            _rigidbody.velocity = _movementDirection * _movementSpeed;
        }

        #endregion

        #region PublicMethods

        //Action
        public void StateMechanic(StateMechanics value) {
            _animator.SetBool(value.ToString(), true);
        }

        public void SetState(States value) {
            CleanAnimatorFlags();
            _state = value;
            //InitializeState();
        }
        // ATTACKING
        public void SetStatesAttacking(State direction) {
            SetState(_state);
            _movementDirection = Vector2.zero;
            StateMechanic(StateMechanics.STOP);
        }
        // Dying
        public void SetStatesDying(States direction) {
            SetState(_state);
            _movementDirection.x = 0;
            _movementDirection.y = 0;
            _movementDirection = Vector2.zero;
            StateMechanic(direction == States.DYING_LEFT ? StateMechanics.DYING_LEFT : StateMechanics.DYING_RIGHT);
        }
        public void SetStatesHurtMePlease(States direction) {
            SetState(direction);
            _movementDirection.x = 0;
            _movementDirection.y = 0;
            _movementDirection = Vector2.zero;
            StateMechanic(StateMechanics.STOP);
        }
        public void SetStatesSprint(Vector2 direction, float sprintMultiplier) {
            _movementDirection = direction;
            _movementSpeed *= sprintMultiplier; // Incrementa velocidad para sprint
            SetState(GetSprintState(direction));
        }
        private States GetSprintState(Vector2 direction) {
            if (direction == Vector2.up) return States.SPRINT_UP;
            if (direction == Vector2.down) return States.SPRINT_DOWN;
            if (direction == Vector2.left) return States.SPRINT_LEFT;
            return States.SPRINT_RIGHT;
        }


        #endregion

        #region GettersSetters

        public Vector2 GetMovementDirection {
            get { return _movementDirection; }
        }

        public Vector2 SetMovementDirection {
            set { _movementDirection = value; }
        }

        public float SetMovementSpeed {
            set { _movementSpeed = value; }
        }

        #endregion
    }
}