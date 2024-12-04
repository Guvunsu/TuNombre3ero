//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyPool : MonoBehaviour
//{
//    #region MethodVariables
//    //[SerializeField] private GameObject m_enemyPool;
//    [SerializeField] private GameObject m_player;
//    bool m_active;

//    #endregion
//    #region UnityMethods
//    void Start()
//    {
//        m_player = GetComponent<GameObject>();
//        m_enemyPool = GetComponent<GameObject>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    #endregion
//    public void OnCollisionEnter2D(Collision2D other)
//    {
//        other.gameObject.CompareTag("Player");
//        if (!m_active)
//        {
//            m_player.SetActive(true);
//        }
//        else
//        {
//            m_player.SetActive(false);
//        }
//    }


//}
