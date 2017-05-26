using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthOrbiter : MonoBehaviour
{
    public bool setOrbitalSpeedOnStart = true;
    public double startAltitude = 300000;

    DRigidbody _drb;
    DRigidbody drb { get { if (!_drb) _drb = GetComponent<DRigidbody>(); return _drb; } }

    private void Awake()
    {
        if (!enabled) return;

        drb.position = new Vector3d(0, startAltitude + Earth.RADIUS, 0);
    }

    private void Start()
    {

        double r = startAltitude + Earth.RADIUS;

        if (setOrbitalSpeedOnStart)
        {
            double speed = GetCircularOrbitSpeed(r);
            drb.velocity = new Vector3d(speed, 0, 0);
        }
    }

    public static double GetCircularOrbitSpeed(double r)
    {
        return Mathd.Sqrt(Earth.GM / r);
    }
}
