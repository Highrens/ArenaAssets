using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToPoint : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player) {
            player.GetComponent<CharacterController>().SimpleMove((transform.position - player.transform.position) * 3);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 8 && player) {

        player = null;
        GetComponent<Switchbox>().isDark = !GetComponent<Switchbox>().isDark;
        }
    }
}
