using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private float textOffset;

    public static TextPopup Create(Vector3 position, string amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.i.OxygenProducedText, position, Quaternion.identity);
        textPopupTransform.Rotate(new Vector3(0f, -90f, 0f));
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount);

        return textPopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        textOffset = Random.value * (Mathf.PI / 2);
    }

    public void Setup(string text)
    {
        textMesh.SetText(text);
        textColor = textMesh.color;
    }

    private void Update()
    {
        float moveYSpeed = 0.4f;
        float moveZSpeed = 3f;

        transform.position += new Vector3(0, moveYSpeed, Mathf.Sin(Time.time * moveZSpeed + textOffset)/2) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0)
        {
            float disappearSpeed = 0.5f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
