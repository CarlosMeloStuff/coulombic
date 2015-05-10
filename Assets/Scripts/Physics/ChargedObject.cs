﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChargedObject : MonoBehaviour
{
    public float charge = 1;
    public float reverseChargeTimer = 0;
    public bool isLocked = false;
    private float reverseChargeTimeCount = 0;

    private GameObject canvasGameObject;
    private static GameObject canvasPrefab;

    private Text canvasText;
    private Image canvasImage;

    void Update()
    {
        if (reverseChargeTimer > 0)
        {
            reverseChargeTimeCount += Time.deltaTime;
            if (reverseChargeTimeCount > reverseChargeTimer)
            {
                reverseChargeTimeCount = 0;
                charge *= -1;
                UpdateAppearance();
            }
        }
    }

    public void UpdateAppearance()
    {
        Color color;
        if (charge > 0)
            color = Color.red;
        else if (charge < 0)
            color = Color.green;
        else
            color = Color.black;
        GetComponent<Renderer>().material.color = color;

        if (canvasGameObject == null)
        {
            canvasGameObject = Instantiate(GetCanvasPrefab(), transform.position, transform.rotation) as GameObject;
            canvasGameObject.transform.SetParent(transform);
        }
        UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        ChargedObjectUI chargedObjectUI=canvasGameObject.GetComponent<ChargedObjectUI>();
        chargedObjectUI.UpdateAppearance(charge,isLocked);
    }

    private GameObject GetCanvasPrefab()
    {
        if (canvasPrefab == null)
            canvasPrefab = Resources.Load("prefabs/ChargeCanvas") as GameObject;
        return canvasPrefab;
    }
}