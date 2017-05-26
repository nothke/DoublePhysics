using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DConstantForce : MonoBehaviour
{
    DRigidbody _drb;
    DRigidbody drb { get { if (!_drb) _drb = GetComponent<DRigidbody>(); return _drb; } }

    public Vector3 force;

    void FixedUpdate()
    {
        drb.AddForce(force);
    }
}
