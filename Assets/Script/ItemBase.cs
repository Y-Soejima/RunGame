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

    public virtual void Item()
    {

    }
}
