using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemA : ItemBase
{
    int purasu = 10;
    [SerializeField] GameManager gm;
    public override void Item()
    {
        Debug.Log("item");
        AddPtime(gm.EndTime);
    }

    public void AddPtime(int timer)
    {
        timer += purasu;
    }
}
