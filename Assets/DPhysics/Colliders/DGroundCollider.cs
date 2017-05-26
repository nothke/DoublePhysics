using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGroundCollider : DCollider
{
    protected override void Respond(DRigidbody drb)
    {
        if (drb.position.y > 0) return;

        drb.position.y = 0;
        drb.velocity.y = 0;
    }
}
