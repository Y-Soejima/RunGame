using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] int m_itemNum;
    public int ItemNum { get; }

    public enum ItemList
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Item()
    {

    }
}
