using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
   private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Door")
        {
            Debug.Log("This is a Door"); //Debug
            

            Animator anim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
                anim.SetTrigger("OpenClose");
        }
    }
}
