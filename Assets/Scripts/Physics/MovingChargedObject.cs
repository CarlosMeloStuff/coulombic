﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ChargedObject))]
public class MovingChargedObject : MonoBehaviour
{
    public float mass = 1;
    public Vector3 startVelocity;
    private Rigidbody rigidbody;
    private ChargedObject chargedObject;

    void Start()
    {
        //throws a LogError if no region manager
        RegionManager.GetMyRegionManager(gameObject);

        GetRigidbody().velocity = startVelocity;
        GetRigidbody().mass = mass;
    }

    void Update()
    {
        if (!GameManager.GetGameManager().HasSimulationBegun())
            GetRigidbody().velocity = Vector3.zero;
    }

    public void SetFrozenPosition(bool isFrozen)
    {
        GetRigidbody().constraints = isFrozen ? RigidbodyConstraints.FreezeAll : RigidbodyConstraints.None;
    }

    public void UpdateValues(ChargedObjectSettings chargedObjectSettings)
    {
        mass = chargedObjectSettings.mass;
        startVelocity = chargedObjectSettings.startVelocity;
        UpdateSize();
    }

    public void ApplyStartVelocity()
    {
        //if this is done while game is paused, it may not work
        if (startVelocity.sqrMagnitude > 0)
            gameObject.GetComponent<Rigidbody>().velocity = startVelocity;
    }

    public void UpdateSize()
    {
        float radius = Mathf.Pow(mass, 0.3333f);
        transform.localScale = new Vector3(1, 1, 1) * radius;
    }

    public ChargedObject GetChargedObject()
    {
        if (chargedObject == null)
            chargedObject = GetComponent<ChargedObject>();
        return chargedObject;
    }

    public float GetCharge()
    {
        return GetChargedObject().charge;
    }

    public void AddForce(Vector3 force)
    {
        if (rigidbody != null)
            rigidbody.AddForce(force);
    }

    public Rigidbody GetRigidbody()
    {
        if (rigidbody == null)
        {
            if (GetComponent<Rigidbody>() == null)
                gameObject.AddComponent<Rigidbody>();
            rigidbody = GetComponent<Rigidbody>();
            if (mass <= 0)
                Debug.LogError("mass is below zero. " + mass);
            rigidbody.mass = mass;
            rigidbody.useGravity = false;
        }
        return rigidbody;
    }
}
