using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTransform : MonoBehaviour
{
    public Vector3d position;

    public bool useTransformPosition;

    private void OnValidate()
    {
        if (useTransformPosition)
            position = new Vector3d(transform.position);
    }
}
