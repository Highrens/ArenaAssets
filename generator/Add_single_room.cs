using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_single_room : MonoBehaviour
{
    public GameObject[] placeroom;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, placeroom.Length);
        var room = Instantiate(placeroom[i], transform.position, transform.rotation);
        room.transform.parent = gameObject.transform;
        Instantiate(wall, room.GetComponent<Room>().Enter_to_new_room.position, transform.rotation);
    }
}
