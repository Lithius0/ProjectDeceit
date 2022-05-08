using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsophagusDrop : MonoBehaviour
{
    [SerializeField] EsophagusStart player;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            player.Drop();
        }
    }
}
