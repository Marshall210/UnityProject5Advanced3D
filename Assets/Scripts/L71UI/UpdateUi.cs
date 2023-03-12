using UnityEngine;
using UnityEngine.UI;

public class UpdateUi : MonoBehaviour
{
    public float speed; // Animation Speed 
    public Graphic[] ui; // UI elements
    private float[] uiAlpha; // Saved alpha channel of UI elements
    private bool[] uiAlphaUpdate; // Saved process of elements

    private void Awake()
    {
        uiAlpha = new float[ui.Length];
        uiAlphaUpdate = new bool[ui.Length];
        // Save alpha channel
        for (var i = 0; i < ui.Length; i++)
            uiAlpha[i] = ui[i].color.a;
    }
    
    private void Update()
    {
        UpdateAlphaChannel();
        //MoveRect();
    }

    // Move elements in random direction
    private void MoveRect()
    {
        for (var i = 0; i < ui.Length; i++)
        {
            ui[i].rectTransform.anchoredPosition 
                += new Vector2(Random.Range(-5f, 5f) * speed, Random.Range(-5f, 5f) * speed);
        }
    }

    // Change alpha channel of UI elements
    private void UpdateAlphaChannel()
    {
        for (var i = 0; i < ui.Length; i++)
        {
            if (!uiAlphaUpdate[i])
            {
                var color = ui[i].color;
                color.a = Mathf.Lerp(color.a, 0, speed);
                ui[i].color = color;

                if (color.a < 0.001f)
                    uiAlphaUpdate[i] = true;
            }
            else
            {
                var color = ui[i].color;
                color.a = Mathf.Lerp(color.a, uiAlpha[i], speed);
                ui[i].color = color;

                if (color.a > uiAlpha[i] - 0.001f)
                    uiAlphaUpdate[i] = false;
            }
        }
    }
}
