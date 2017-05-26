using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPhysicsManager : MonoBehaviour
{

    static int step;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
            ChangeTimeScale(1);

        if (Input.GetKeyDown(KeyCode.Minus))
            ChangeTimeScale(-1);
    }

    public static void ChangeTimeScale(int by)
    {
        step += by;
        DRigidbody.timeScale = Mathf.Pow(step, 2);
    }
}
