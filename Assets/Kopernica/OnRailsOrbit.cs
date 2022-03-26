using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRailsOrbit : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform parentBody;
    [SerializeField] float orbitSpeed = 1;

    [SerializeReference] private float theta;
    [SerializeReference] private float distance;


    void Start()
    {
        Vector3 localPosition = parentBody.position - transform.position;
        distance = (localPosition).magnitude;
        theta = Mathf.Atan2(localPosition.y, localPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        theta += Time.deltaTime * orbitSpeed;
        while (theta > 360)
        {
            theta -= 360;
        }

        this.transform.position = parentBody.transform.position + (Quaternion.Euler(0, 0, theta) * new Vector3(distance, 0, 0));
    }
}
