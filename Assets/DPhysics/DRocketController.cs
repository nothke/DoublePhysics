using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(DRigidbody))]
public class DRocketController : MonoBehaviour
{
    Rigidbody _rb;
    Rigidbody rb { get { if (!_rb) _rb = GetComponent<Rigidbody>(); return _rb; } }

    DRigidbody _drb;
    DRigidbody drb { get { if (!_drb) _drb = GetComponent<DRigidbody>(); return _drb; } }

    public float thrustMult;
    public float torqueMult;

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.AddTorque(Vector3.forward * input.x * torqueMult);
        drb.AddForce(transform.up * input.z * thrustMult);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.up);
    }
}