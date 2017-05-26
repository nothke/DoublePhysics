using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRigidbody : MonoBehaviour
{
    public static float timeScale = 1;
    float DeltaTime { get { return Time.fixedDeltaTime * timeScale; } }

    public bool updateTransform = true;
    public Vector3d position;
    public Vector3d velocity;

    Vector3d gravity = new Vector3d(0, 0, 0);
    //Vector3d gravity = new Vector3d(0, -9.81, 0);

    Vector3d addedForce;

    public Vector3 startingForce;

    void Start()
    {
        if (position == Vector3d.zero)
            position = new Vector3d(transform.position);

        AddForce(startingForce);
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
