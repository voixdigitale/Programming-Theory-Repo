using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    [SerializeField] protected float _oxygenProduction;
    protected float _CO2Absorption;
    protected int productionTick;

    //ENCAPSULATION
    [SerializeField]
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

    public virtual void Start()
    {
        MainManager.i.OxygenRate += OxygenProduction;
        SubscribeToTickSystem();
    }

    protected void SubscribeToTickSystem()
    {
        productionTick = 0;

        TimeTickSystem.OnTick += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
        {
            if (productionTick < 3)
            {
                productionTick++;
            }
            else
            {
                if (this) ProduceOxygen();
            }
        };
    }

    //POLYMORPHISM
    public abstract void ProduceOxygen();

}
