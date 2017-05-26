using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DTransform))]
public class DCollider : MonoBehaviour
{
    public Vector3d position { get { return new Vector3d(transform.position); } }

    public Color gizmoColor { get { return Color.yellow; } }

    static DRigidbody[] _drbs;
    public static DRigidbody[] drbs
    {
        get
        {
            if (_drbs == null)
                _drbs = FindObjectsOfType<DRigidbody>();

            return _drbs;
        }
    }

    private void FixedUpdate()
    {
        foreach (var drb in drbs)
        {
            Respond(drb);
        }
    }

    protected virtual void Respond(DRigidbody drb)
    {

    }
}
