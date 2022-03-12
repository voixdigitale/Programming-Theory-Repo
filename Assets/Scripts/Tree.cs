using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Plant
{
    public override void ProduceOxygen()
    {
        Vector3 startPos = transform.position;
        startPos.x += 0.5f;
        startPos.y += transform.lossyScale.y * 1.5f;
        TextPopup.Create(startPos, _oxygenProduction.ToString("F2"));
        productionTick = 0;
    }
}