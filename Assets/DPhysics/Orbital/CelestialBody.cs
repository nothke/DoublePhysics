using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DTransform))]
public class CelestialBody : MonoBehaviour
{
    DTransform _dt;
    public DTransform dTransform { get { if (!_dt) _dt = GetComponent<DTransform>(); return _dt; } }

    protected GravityPoint gravityPoint;
    protected DSphereCollider dCollider;

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        gravityPoint = gameObject.AddComponent<GravityPoint>();
        dCollider = gameObject.AddComponent<DSphereCollider>();
    }
}
