using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSphereCollider : DCollider
{

    public double radius = 1;

    protected override void Respond(DRigidbody drb)
    {
        if (Vector3d.SqrMagnitude(position - drb.position) < radius * radius)
        {
            Vector3d contactPosition = Vector3d.ClampMagnitude(drb.position - position, radius) + position;

            drb.position = contactPosition;

            drb.AddForce(new Vector3d(0, 9.81, 0));

            
            Vector3d diff = drb.position - position;
            Vector3d normal = diff.normalized;

            Debug.DrawRay((Vector3)contactPosition, (Vector3)normal);

            if (Vector3d.Dot(normal, drb.velocity) < 0)
                drb.velocity = Vector3d.ProjectOnPlane(drb.velocity, normal);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, (float)radius);
    }
}
