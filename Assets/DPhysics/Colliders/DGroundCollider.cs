using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGroundCollider : DRigidbodyEffector
{
    protected override void Respond(DRigidbody drb)
    {
        if (drb.position.y > 0) return;

        drb.position = new Vector3d(drb.position.x, 0, drb.position.z);
        drb.velocity.y = 0;
    }
}
