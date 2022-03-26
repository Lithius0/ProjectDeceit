using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotated : MonoBehaviour
{
    [SerializeField] GameObject focus;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {

        if (focus)
        {
            transform.position = focus.transform.position + new Vector3(0, 0, -8);
        }

    }
}
