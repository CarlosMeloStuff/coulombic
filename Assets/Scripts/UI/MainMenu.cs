﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public Canvas puzzleCanvas,creditsCanvas;
    public Button[] mainButtons;


	// Use this for initialization
	void Start () {
        SetVisibility(puzzleCanvas, false);
        SetVisibility(creditsCanvas, false);
	}

    public void PuzzlePress()
    {
        SetVisibility(puzzleCanvas, true);
        SetVisibility(creditsCanvas, false);
    }

    public void CreditsPress()
    {
        SetVisibility(puzzleCanvas, false);
        SetVisibility(creditsCanvas, true);
    }

    public void ChoosePuzzlePress(int levelID)
    {
        Application.LoadLevel(levelID);
    }

    public void ExitPress()
    {
        Application.Quit();
    }

    public static void SetVisibility(Canvas canvas,bool isVisible)
    {
        foreach (GameObject child in ParentChildFunctions.GetAllChildren(canvas.gameObject, true))
        {
            if (child.GetComponent<Canvas>() != null)
                child.GetComponent<Canvas>().enabled = isVisible;
            if (child.GetComponent<Image>() != null)
                child.GetComponent<Image>().enabled = isVisible;
            if (child.GetComponent<Text>() != null)
                child.GetComponent<Text>().enabled = isVisible;
            if (child.GetComponent<Button>() != null)
                child.GetComponent<Button>().enabled = isVisible;
        }
    }
}