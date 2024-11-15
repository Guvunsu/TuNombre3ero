using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SotomaYorch.DungeonCrawler
{
    [RequireComponent(typeof(Collider2D))]
    public class Hitbox : MonoBehaviour
    {
        #region KnobsParameters
        // public uint damage =1;
        public float lifetime = 1f;
        #endregion KnobsParameters

        #region References

        [SerializeField] protected Collider2D _collider;

        #endregion References
        #region RuntimeVariables
        bool _isHitBoxActive;
        #endregion RuntimeVariables

        #region UnityMethods

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if (_collider == null)
            {
                _collider = GetComponent<Collider2D>();
            }
#endif
        }

        #endregion UnityMethods

        #region PublicMethods
        public void ActivateHitBox()
        {
            if (!_isHitBoxActive)
            {

                StartCoroutine(lifeTime());
            }
        }
        #region Coroutines
        public IEnumerator lifeTime()
        {
            _isHitBoxActive = true;
            _collider.enabled = true;
            yield return new WaitForSeconds(lifetime);
            _collider.enabled = false;
            _isHitBoxActive = false;
        }
        #endregion Coroutines

        #endregion PublicMethods
    }
}
