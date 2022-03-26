using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class TransitionlessTeleporter : MonoBehaviour
{
    [SerializeField] GameObject teleportTo;
    private List<Collider2D> received = new List<Collider2D>();

    protected void AddObjectReceieved(Collider2D objectReceived)
    {
        received.Add(objectReceived);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!received.Contains(other))
        {
            other.transform.Translate(-this.transform.position);
            other.transform.Translate(teleportTo.transform.position);

            TransitionlessTeleporter receiver = teleportTo.GetComponent<TransitionlessTeleporter>();
            if (receiver)
            {
                receiver.AddObjectReceieved(other);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (received.Contains(other))
        {
            received.Remove(other);
        }
    }
}
