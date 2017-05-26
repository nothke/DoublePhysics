using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DTransform))]
public abstract class DRigidbodyEffector : MonoBehaviour
{
    DTransform _dt;
    public DTransform dTransform { get { if (!_dt) _dt = GetComponent<DTransform>(); return _dt; } }

    public Vector3d position { get { return dTransform.position; } }

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

    protected abstract void Respond(DRigidbody drb);
}
