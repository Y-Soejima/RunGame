using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class CameraControler : MonoBehaviour
{
    [SerializeField] private GameObject m_plaerPrefab;
    [SerializeField] private float m_offset;
    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] GameManager m_gm;
    void Start()
    {
        transform.position = new Vector3(m_plaerPrefab.transform.position.x + m_offset, transform.position.y, transform.position.z);
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_gm.m_gameStart.Subscribe(_=> StartCoroutine(Camera()));
    }
    void Update()
    {
        if (m_plaerPrefab)
        {
            MoveCamera();
        }
        
    }

    void MoveCamera()
    {
       
    }
   
    IEnumerator Camera()
    {
        while(m_gm.m_player != null)
        {
            m_rigidbody.velocity = new Vector2(m_plaerPrefab.GetComponent<Player>().m_speed, m_rigidbody.velocity.y);
            yield return new WaitForEndOfFrame();
        }
    }
}
