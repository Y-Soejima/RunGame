using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private GameObject m_plaerPrefab;
    [SerializeField] private float m_offset;
   
    void Update()
    {
        if (m_plaerPrefab)
        {
            MoveCamera();
        }
        
    }

    void MoveCamera()
    {
        transform.position = new Vector3(m_plaerPrefab.transform.position.x + m_offset, transform.position.y, transform.position.z);
    }
}
