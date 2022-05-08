using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    //Mapping transforms to masses
    [SerializeField] Transform[] bodyPositions;
    [SerializeField] float[] bodyMasses;
    [SerializeReference] float gravitationalConstant = 1;
    [SerializeField] LineRenderer[] lines;
    [SerializeField] LineRenderer pushLine;
    [SerializeField] Vector2 initialVelocity;

    [SerializeReference] float pushMagnitude;


    private void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = initialVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        for (int i = 0; i < bodyPositions.Length; i++)
        {

            Vector3 vectorToGravitySource = bodyPositions[i].position - transform.position;
            //Distance is already squared
            float force = (gravitationalConstant * bodyMasses[i] * GetComponent<Rigidbody2D>().mass) / (vectorToGravitySource.sqrMagnitude);

            this.GetComponent<Rigidbody2D>().AddForce(vectorToGravitySource.normalized * force * Time.fixedDeltaTime);
            lines[i].SetPosition(1, vectorToGravitySource.normalized * force * 0.02f);
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 forceVector = new Vector2(h, v);
        forceVector = forceVector.normalized * pushMagnitude;

        GetComponent<Rigidbody2D>().AddForce(forceVector * Time.fixedDeltaTime);
        pushLine.SetPosition(1, forceVector * 0.02f);


    }

    private void OnDisable()
    {
        foreach (LineRenderer line in lines)
        {
            line.SetPosition(1, Vector3.zero);
        }
        pushLine.SetPosition(1, Vector3.zero);
    }
}
