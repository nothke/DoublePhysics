using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPoint : DRigidbodyEffector
{
    public double multiplier = 1000;

    protected override void Respond(DRigidbody drb)
    {
        double sqrMagnitude = Vector3d.SqrMagnitude(position - drb.position);

        Vector3d dir = (position - drb.position).normalized;
        Vector3d force = dir * multiplier / sqrMagnitude;
        drb.AddForce(force);
    }
}
