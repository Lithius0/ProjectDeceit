using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    [SerializeField] GameObject focus;

    // Update is called once per frame
    void Update()
    {
        if (focus)
        {
            transform.position = focus.transform.position + new Vector3(0, 0, -8);
        }

    }
}
