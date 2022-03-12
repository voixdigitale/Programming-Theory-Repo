using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    public TMP_Text OxygenRateText;

    private float rate;

    private void Start()
    {
        rate = MainManager.i.OxygenRate;
    }

    private void Update()
    {
        if (rate != MainManager.i.OxygenRate)
        {
            UpdateMessage();
            rate = MainManager.i.OxygenRate;
        }
    }

    // Update is called once per frame
    public void UpdateMessage()
    {
        OxygenRateText.text = "Oxygen rate: " + MainManager.i.OxygenRate.ToString() + " g / s";
    }
}
