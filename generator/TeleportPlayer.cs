using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
   public Transform teleportTo;
   private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 8) {
        other.transform.Translate(teleportTo.position, Space.World);
       // other.gameObject.GetComponent<CharacterController>().Move(teleportTo.localPosition);
    }
   }
}
