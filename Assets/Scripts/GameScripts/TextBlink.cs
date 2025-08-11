using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class TextBlink : MonoBehaviour
{
    //Text that is blinking.
    [SerializeField] TMP_Text tmpText;
    //Array of colors used for text.
    public Color[] colors = new Color[3] { Color.red, Color.blue, Color.green };
    //Changeable interval for faster or slower blinking.
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
        //Check every frame if timer is the same as blink iterval, then change color.
        timer += Time.deltaTime;
        if (timer >= blinkInterval)
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            tmpText.color = colors[currentColorIndex];
            timer = 0f;
        }
    }
}
