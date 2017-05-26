using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microworld : MonoBehaviour
{

    public DRigidbody drb;

    public Earth earth;

    public Transform fakeDRB;
    public Transform fakeEarth;

    public double scaleMult = 0.0000001f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fakeEarth.position = (Vector3)(earth.GetComponent<GravityPoint>().position * scaleMult);
        fakeEarth.localScale = Vector3.one * 2 * (float)(Earth.RADIUS * scaleMult);

        fakeDRB.position = (Vector3)(drb.position * scaleMult);
        fakeDRB.rotation = drb.transform.rotation;
    }
}
