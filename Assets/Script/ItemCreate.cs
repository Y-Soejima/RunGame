using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] ItemBase[] m_itemList = new ItemBase[System.Enum.GetValues(typeof(ItemBase.ItemList)).Length];
    void Start()
    {
        int item = Random.Range(0, m_itemList.Length);
        Instantiate(m_itemList[item]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
