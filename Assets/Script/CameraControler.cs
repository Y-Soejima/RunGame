using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private GameObject m_plaerPrefab;
    [SerializeField] private float m_offset;
    [SerializeField] private Rigidbody2D m_rigidbody;

    void Start()
    {
        transform.position = new Vector3(m_plaerPrefab.transform.position.x + m_offset, transform.position.y, transform.position.z);
        m_rigidbody = GetComponent<Rigidbody2D>();
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
       m_rigidbody.velocity = new Vector2(m_plaerPrefab.GetComponent<Player>().m_speed, m_rigidbody.velocity.y);
    }
   
}
