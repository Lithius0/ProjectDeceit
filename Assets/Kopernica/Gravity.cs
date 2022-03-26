using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    //Mapping transforms to masses
    [SerializeField] Transform[] bodyPositions;
    [SerializeField] float[] bodyMasses;
    [SerializeReference] float gravitationalConstant = 1;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        for (int i = 0; i < bodyPositions.Length; i++)
        {

            Vector3 vectorToGravitySource = bodyPositions[i].position - transform.position;
            //Distance is already squared
            float force = (gravitationalConstant * bodyMasses[i] * GetComponent<Rigidbody2D>().mass) / (vectorToGravitySource.sqrMagnitude);

            this.GetComponent<Rigidbody2D>().AddForce(vectorToGravitySource.normalized * force);
            Debug.DrawRay(transform.position, vectorToGravitySource.normalized * force, Color.red);
        }

        //TODO: Add userinput movement
    }
}
