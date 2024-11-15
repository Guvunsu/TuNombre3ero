using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.DungeonCrawler
{

    public class Hurtbox : MonoBehaviour
    {
        #region RuntimeVaribales

        protected bool _isInCooldown;

        #endregion RuntimeVariables

        #region UnityMethods

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_isInCooldown)
            {
                // i have the potencialñ to be harmed by a hitbox :O
                if (other.gameObject.CompareTag("Hitbox"))
                {
                    // this hitbox may hurt me if it is from anopther type of entity -> Friendly Fire = false
                    if (other.gameObject.layer != gameObject.layer)
                    {
                        //damn, i am about to be hurt Dx
                    }
                }
            }
        }

        #endregion UnityMethods
    }
}
