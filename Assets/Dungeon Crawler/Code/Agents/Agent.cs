using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SotomaYorch.DungeonCrawler {
    #region Enums


    #endregion

    #region Structs


    #endregion

    //Agent cannot operate without the Rigidbody2D
    [RequireComponent(typeof(Rigidbody2D))]
    public class Agent : MonoBehaviour {
        //Configuration parameter of this script
        #region Knobs

        public int maxHealthPoints = 3;

        #endregion

        #region References

        [SerializeField] protected Rigidbody2D _rigidbody;
        [SerializeField] protected FiniteStateMachine _fsm;

        #endregion

        #region RuntimeVariables

        protected Vector2 _movementDirection;
        protected StateMechanics _movementStateMechanic;

        #endregion

        #region LocalMethods

        protected virtual void CalculateStateMechanicDirection() {
            if (Vector2.Dot(_fsm.GetMovementDirection, Vector2.down) >= 0.5f) {
                _movementStateMechanic = StateMechanics.MOVE_DOWN;
            } else if (Vector2.Dot(_fsm.GetMovementDirection, Vector2.right) >= 0.5f) {
                _movementStateMechanic = StateMechanics.MOVE_RIGHT;
            } else if (Vector2.Dot(_fsm.GetMovementDirection, Vector2.up) >= 0.5f) {
                _movementStateMechanic = StateMechanics.MOVE_UP;
            } else {
                _movementStateMechanic = StateMechanics.MOVE_LEFT;
            }
        }

        public void OnMove(InputValue value) {
            _movementDirection = value.Get<Vector2>(); // Obtener la direcci�n del input
        }
        #endregion

        #region UnityMethods

        //private void Start() {
        //    //InitializeAgent();
        //}

        //ranges from 24 to 200 FPS
        //(according to the computer)
        //void Update() {

        //}

        //private void PhysicsUpdate()
        //private void FixedUpdate() {
        //    //when we update the rigid body, we do it
        //    //during the Physics thread update
        //    //which is the FixedUpdate()
        //    //within the PhysX Engine (by NVidia) in Unity
        //    //_rigidbody.velocity = Vector3.right;
        //    //_rigidbody.AddForce(Vector2.right);
        //}

        #endregion

        #region PublicMethods

        public virtual void InitializeAgent() {
            //With the RequireComponent we guarantee
            //this reference will be ALWAYS retreived
            /*
            _rigidbody = GetComponent<Rigidbody2D>();
            if (_rigidbody == null ) {
                Debug.LogError("Rigid body has not been assigned to " +
                    gameObject.name);
            }
            */
        }

        #endregion

        #region GettersSetters

        #endregion
    }
}