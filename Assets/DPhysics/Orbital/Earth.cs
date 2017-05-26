using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{

    public const double GM = 3.986004418e+14;
    public const double RADIUS = 6371000;

    GravityPoint gravityPoint;
    DSphereCollider dCollider;

    void Start()
    {
        gravityPoint = gameObject.AddComponent<GravityPoint>();
        gravityPoint.multiplier = GM;

        //transform.position = new Vector3(0, (float)-RADIUS - 10, 0);

        dCollider = gameObject.AddComponent<DSphereCollider>();
        dCollider.radius = RADIUS;
    }
}
