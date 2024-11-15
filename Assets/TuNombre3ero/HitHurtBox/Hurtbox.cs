using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SotomaYorch.DungeonCrawler
{

    public class Hurtbox : MonoBehaviour
    {
        #region KnobsParameters

        public int maxHealthPoints = 3; //vida maxima par amis agentes
        public float coolDownTime = 1.0f; // damage por segundo "DPS" al HITBOX

        #endregion KnobsParameters

        #region References

        [SerializeField] protected Agent _agent;
        #endregion References


        #region RuntimeVaribales

        protected bool _isInCooldown;
        protected int _currentHealthPoints;

        #endregion RuntimeVariables

        #region UnityMethods
        private void OnDrawGizmos()
        {

            if (_agent != null)
            {
                transform.parent.gameObject.GetComponent<Agent>()];
            }
        }
        void Start()
        {
            _currentHealthPoints = maxHealthPoints;
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_isInCooldown)// to be inmune or not :3
            {
                // i have the potencialñ to be harmed by a hitbox :O
                if (other.gameObject.CompareTag("Hitbox"))
                {
                    // this hitbox may hurt me if it is from anopther type of entity -> Friendly Fire = false
                    if (other.gameObject.layer != gameObject.layer)
                    {
                        //damn, i am about to be hurt Dx
                        _currentHealthPoints -= 1; // other.gameObject.GetComponent<Hitbox>().GetDamage;

                        if (_currentHealthPoints <= 0)
                        {
                            //so i will die, it is time :,(
                        }
                        else
                        {
                            StartCoroutine(Cooldown());
                        }
                    }
                }
            }
        }

        #endregion UnityMethods

        #region Coroutines

        protected IEnumerator Cooldown()
        {
            _isInCooldown = true; //to be Inmune for a certain time;
            yield return new WaitForSeconds(coolDownTime); // to be inmune for some time 
            _isInCooldown = false;
        }

        #endregion Coroutines
    }
}
