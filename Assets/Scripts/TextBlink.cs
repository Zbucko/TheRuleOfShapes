using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class TextBlink : MonoBehaviour
{
    [SerializeField] TMP_Text tmpText;
    public Color[] colors = new Color[3] { Color.red, Color.blue, Color.green };
    public float blinkInterval = 0.5f;

    private float timer;
    private int currentColorIndex = 0;
    void Start()
    {
        if (tmpText == null)
        {
            tmpText = GetComponent<TMP_Text>();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= blinkInterval)
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            tmpText.color = colors[currentColorIndex];
            timer = 0f;
        }
    }
}
