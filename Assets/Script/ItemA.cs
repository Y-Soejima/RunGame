using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemA : ItemBase
{
    int purasu = 10;
    [SerializeField] GameManager gm;
    public override void Item()
    {
        AddPtime();
    }

    public void AddPtime()
    {
        gm.EndTime += purasu;
    }
}
