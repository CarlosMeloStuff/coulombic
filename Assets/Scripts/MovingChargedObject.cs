﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(ChargedObject))]
public class MovingChargedObject : MonoBehaviour
{    
    public float mass = 1;
    public Vector3 startVelocity;
    private Rigidbody rigidbody;
    private ChargedObject chargedObject;

    void Start()
    {
        GetRigidbody().velocity = startVelocity;
        GetRigidbody().mass = mass;
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
