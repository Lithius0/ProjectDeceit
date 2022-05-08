using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class EnableGravity : MonoBehaviour
{
    [SerializeField] CameraTest c;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        Gravity playerFreemove = other.gameObject.GetComponent<Gravity>();
        if (player && playerFreemove)
        {
            player.gravityModifier = 3;
            player.enabled = true;
            playerFreemove.enabled = false;
            other.gameObject.transform.localScale = new Vector3(2, 2, 2);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (c)
        {
            c.distance = 15;
        }
    }
}
