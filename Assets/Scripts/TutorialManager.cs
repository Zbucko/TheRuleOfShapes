using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using static ShapeSwitcher;

public class TutorialManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public ShapeSwitcher shapeSwitcher;
    public TextMeshProUGUI tutorialMessage;

    private bool correctShapeChanged = false;
    void OnEnable()
    {
        ShapeSwitcher.OnShapeChanged += HandleShapeChanged;
    }

    void OnDisable()
    {
        ShapeSwitcher.OnShapeChanged -= HandleShapeChanged;       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Disable player movement and display messages at the start of tutorial.
        StartCoroutine(TutorialSequence());
    }

    private IEnumerator TutorialSequence()
    {
        //Disable player movement and shape change.
        playerMovement.enabled = false;
        shapeSwitcher.enabled = true;

        //Welcome message.
        tutorialMessage.text = "Welcome to the tutorial!";
        tutorialMessage.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        //Step 1: Ask player to change to Cube.
        tutorialMessage.text = "Press 1 to change to cube!";
        tutorialMessage.gameObject.SetActive(true);

        correctShapeChanged = false;
        yield return new WaitUntil(() => correctShapeChanged);

        tutorialMessage.text = "Great! Now press 2 to change to sphere!";

        correctShapeChanged = false;
        yield return new WaitUntil(() => correctShapeChanged);

        tutorialMessage.text = "Awesome! Now press 3 to change to pyramid!";

        correctShapeChanged = false;
        yield return new WaitUntil(() => correctShapeChanged);

        tutorialMessage.text = "Use left and right arrow keys to move.";
        tutorialMessage.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        tutorialMessage.text = "Well done! Now pass this simple level to complete the tutorial!";

        yield return new WaitForSeconds(2f);

        tutorialMessage.gameObject.SetActive(false);
        playerMovement.enabled = true;
    }

    private void HandleShapeChanged(ShapeSwitcher.Shape newShape)
    {
        if (tutorialMessage.text.Contains("cube") && newShape == ShapeSwitcher.Shape.Cube)
        {
            correctShapeChanged = true;
        }
        else if (tutorialMessage.text.Contains("sphere") && newShape == ShapeSwitcher.Shape.Sphere)
        {
            correctShapeChanged = true;
        }
        else if (tutorialMessage.text.Contains("pyramid") && newShape == ShapeSwitcher.Shape.Pyramid)
        {
            correctShapeChanged = true;
        }
    }
}
