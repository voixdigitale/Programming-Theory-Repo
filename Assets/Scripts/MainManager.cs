using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager i;
    public float OxygenRate;

    private void Awake()
    {
        if (i != null)
        {
            Destroy(gameObject);
            return;
        }

        i = this;
        DontDestroyOnLoad(gameObject);
    }
    public void OnOxygenateButtonClicked()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
    