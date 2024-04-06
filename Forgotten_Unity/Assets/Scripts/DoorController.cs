using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    private Animator anim;

    private void Start()
    {
        // Get the Animator component from the children of this GameObject
        anim = GetComponentInChildren<Animator>();
        if (anim == null)
        {
            UnityEngine.Debug.LogError("Animator component not found in children.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player is tagged as "Player"
        {
            isPlayerInTrigger = true;
            UnityEngine.Debug.Log("Can Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player is tagged as "Player"
        {
            isPlayerInTrigger = false;
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown("e")) // e key opens the door
        {
            if (anim != null)
            {
                anim.SetTrigger("OpenClose");
            }
        }
    }
}
