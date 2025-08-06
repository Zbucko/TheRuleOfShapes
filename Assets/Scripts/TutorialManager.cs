using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using static ShapeSwitcher;

public class TutorialManager : MonoBehaviour
{
    //Use of hashset so we don't have duplicate used shapes and all have to be used.
    private HashSet<ShapeSwitcher.Shape> usedShapes = new HashSet<ShapeSwitcher.Shape>();

    public PlayerMovement playerMovement;
    void OnEnable()
    {
        ShapeSwitcher.OnShapeChanged += HandleShapeChanged;
    }

    void Osable()
    {
        ShapeSwitcher.OnShapeChanged -= HandleShapeChanged;       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Disable player movement at the start of tutorial.
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }

    private void HandleShapeChanged(ShapeSwitcher.Shape newShape)
    {
        usedShapes.Add(newShape);
        Debug.Log("Promenjen oblik u: " + newShape);

        if (usedShapes.Count == 3)
        {
            Debug.Log("Svi oblici promenjeni!");
            if (playerMovement != null)
            {
                playerMovement.enabled = true;
            }
        }
    }
}
