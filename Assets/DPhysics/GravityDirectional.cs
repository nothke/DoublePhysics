using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDirectional : DRigidbodyEffector
{
    public Vector3 acceleration = new Vector3(0, -9.81f, 0);

    protected override void Respond(DRigidbody drb)
    {
        drb.AddForce(acceleration);
    }
}
