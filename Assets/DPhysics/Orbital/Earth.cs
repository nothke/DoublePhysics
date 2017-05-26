using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : CelestialBody
{
    public const double GM = 3.986004418e+14;
    public const double RADIUS = 6371000;

    protected override void Initialize()
    {
        base.Initialize();

        gravityPoint.multiplier = GM;
        dCollider.radius = RADIUS;
        //dTransform.position = new Vector3d(0, -RADIUS - 10, 0);
    }
}
