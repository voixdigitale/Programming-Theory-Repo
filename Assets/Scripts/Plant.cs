using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{ 
    private float _oxygenProduction = 0.27f;
    private float _CO2Absorption;
    private int productionTick;
    
    //ENCAPSULATION
    public float OxygenProduction
    {
        get
        {
            return _oxygenProduction;
        }
        set
        {
            //always positive
            if (OxygenProduction > 0)
            {
                _oxygenProduction = OxygenProduction;
            }
            else
            {
                _oxygenProduction = 0;
            }
            
        }
    }

    //ENCAPSULATION
    public float CO2Absorption
    {
        get
        {
            return _CO2Absorption;
        }
        set
        {
            //always negative
            if (CO2Absorption < 0)
            {
                _CO2Absorption = CO2Absorption;
            }
            else
            {
                _CO2Absorption = 0;
            }
            
        }
    }

    void Start()
    {
        productionTick = 0;

        TimeTickSystem.OnTick += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
        {
            if (productionTick < 3)
            {
                productionTick++;
            } else
            {
                Vector3 startPos = transform.position;
                startPos.x += 0.5f;
                startPos.y += transform.lossyScale.y * 1.5f;
                TextPopup.Create(startPos, _oxygenProduction.ToString("F2"));
                productionTick = 0;
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
