using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

using UnityEngine.SceneManagement;

public class EsophagusStart : MonoBehaviour
{
    private float prelaunchGravity;
    private PlayerController player;
    bool firstStart = true;



    void LateUpdate()
    {
        //For whatever reason launch won't work on scene load. This ensures that it happens after everything else has loaded
        //Jank AF lmao
        if (firstStart)
        {
            player = this.GetComponent<PlayerController>();
            Launch();
            firstStart = false;
        }
    }

    public void Launch()
    {
        player.jumpState = PlayerController.JumpState.InFlight;
        prelaunchGravity = player.gravityModifier;
        player.gravityModifier = 0;
        player.controlEnabled = false;
        player.AddVelocity(new Vector2(30, 0));
    }
    public void Drop()
    {
        player.controlEnabled = true;
        player.gravityModifier = prelaunchGravity;
    }
}
