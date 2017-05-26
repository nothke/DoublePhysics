using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteDebug : MonoBehaviour
{
    public Earth earth;
    public DRigidbody drb;

    public double r;
    public double alt;
    public double orbV;
    public double circV;
    public double vertV;

    public void Update()
    {
        Vector3d diff = earth.gameObject.GetComponent<GravityPoint>().position - drb.position;

        r = Vector3d.Magnitude(diff);
        alt = r - Earth.RADIUS;

        orbV = Vector3d.ProjectOnPlane(drb.velocity, diff.normalized).magnitude;
        circV = EarthOrbiter.GetCircularOrbitSpeed(r);
        vertV = Vector3d.Project(drb.velocity, diff.normalized).magnitude;
    }
}
