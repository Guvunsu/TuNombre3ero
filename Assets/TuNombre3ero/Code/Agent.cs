using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FSM;

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
        public float cooldownDamageTime = 1f;

        #endregion

        #region References

        [SerializeField, HideInInspector] protected Rigidbody2D _rigidbody;
        [SerializeField, HideInInspector] protected FSM _fsm;
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        #endregion

        #region RuntimeVariables

        protected Vector2 _movementDirection;
        protected agentFSM _movementStateMechanic;
        [SerializeField] protected Color _spriteRendererColor;
        protected bool _cooldown;
        protected float _cooldownCronometer;
        protected Coroutine _blinkDamgeCoroutine;

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

        //Invocation from the HurtBox of this same agent
        protected virtual void DamageAgent() {
            if (!_cooldown) {
                _cooldown = true;
                _cooldownCronometer = cooldownDamageTime;
                _blinkDamgeCoroutine = StartCoroutine(DamageBlink());
            }
        }

        protected IEnumerator DamageBlink() {
            while (_cooldownCronometer > 0) {
                _spriteRendererColor.a = 0.25f;
                _spriteRenderer.color = _spriteRendererColor;
                yield return new WaitForSeconds(0.25f);
                _spriteRendererColor.a = 1f;
                _spriteRenderer.color = _spriteRendererColor;
                yield return new WaitForSeconds(0.25f);
                _cooldownCronometer -= 0.5f; //0.25f + 0.25f
            }
            StopCoroutine(_blinkDamgeCoroutine);
            _blinkDamgeCoroutine = null;
            _cooldown = false;
        }

        #endregion

        #region UnityMethods

        private void OnDrawGizmos()  //Upate() in Editor mode
        {
            InitializeAgent();
        }

        private void Start() {
            //InitializeAgent();
        }

        //ranges from 24 to 200 FPS
        //(according to the computer)
        void Update() {

        }

        //private void PhysicsUpdate()
        private void FixedUpdate() {
            //when we update the rigid body, we do it
            //during the Physics thread update
            //which is the FixedUpdate()
            //within the PhysX Engine (by NVidia) in Unity
            //_rigidbody.velocity = Vector3.right;
            //_rigidbody.AddForce(Vector2.right);
        }

        #endregion

        #region PublicMethods

        public virtual void InitializeAgent() {
            if (_spriteRenderer == null) {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            if (_spriteRendererColor == null) {
                _spriteRendererColor = _spriteRenderer.color;
            }
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

        public void StateMechanic(StateMechanics value) {
            _fsm.StateMechanic(value);
        }

        #endregion

        #region GettersSetters

        #endregion
    }
}

