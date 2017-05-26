using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DTransform))]
public class DRigidbody : MonoBehaviour
{
    DTransform _dt;
    DTransform dTransform { get { if (!_dt) _dt = GetComponent<DTransform>(); return _dt; } }

    public static float timeScale = 1;
    float DeltaTime { get { return Time.fixedDeltaTime * timeScale; } }

    public bool updateTransform = true;
    public Vector3d position { get { return dTransform.position; } set { dTransform.position = value; } }
    public Vector3d velocity;

    Vector3d gravity = new Vector3d(0, 0, 0);
    //Vector3d gravity = new Vector3d(0, -9.81, 0);

    Vector3d addedForce;

    void Start()
    {
        if (position == Vector3d.zero)
            position = new Vector3d(transform.position);
    }

    public void AddForce(Vector3 force)
    {
        AddForce(new Vector3d(force));
    }

    public void AddForce(Vector3d force)
    {
        addedForce += force;
    }

    
    void Update()
    {
        if (updateTransform)
            transform.position = WrappedPosition();
    }

    private void FixedUpdate()
    {
        velocity += (gravity + addedForce) * DeltaTime;

        position += velocity * DeltaTime;
        addedForce = Vector3d.zero;
    }

    Vector3 WrappedPosition()
    {
        float limit = 1000;
        float x = (float)(Wrap(position.x, limit));
        float y = (float)(Wrap(position.y, limit));
        float z = (float)(Wrap(position.z, limit));

        return new Vector3(x, y, z);
    }

    double Wrap(double d, double limit)
    {
        return ((d + limit) % (limit * 2)) - limit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(WrappedPosition(), 0.5f);
    }
}
