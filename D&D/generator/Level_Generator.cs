using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level_Generator : MonoBehaviour
{
    public int roomcount;
     int roomcount_max;
    int i = 1;

    public GameObject[] RoomPrefabs;
   public  GameObject[] placedroom;
    public GameObject firstRoom;
    public GameObject finishRoom;
    public GameObject[] BossRooms;
    public GameObject[] prize_room;
    public GameObject[] ShopRoom;
      int selectedRoom;
    public float Distance;
    int room_spawned_amount = 1;
    // Start is called before the first frame update
    void Start()
    {
        roomcount_max = roomcount + 4;
        placedroom = new GameObject[roomcount_max];
        placedroom[0] = firstRoom;
        placedroom[Random.Range(roomcount_max / 2, roomcount_max - 2)] = ShopRoom[Random.Range(0, ShopRoom.Length)]; //Магазин
        placedroom[Random.Range(1, roomcount_max / 2)] = prize_room[Random.Range(0, prize_room.Length)]; //Призовая
        placedroom[roomcount_max - 2] = BossRooms[Random.Range(0, BossRooms.Length)]; // Босс
        placedroom[roomcount_max - 1] = finishRoom; // RoomPrefabs[0]; //Финиш


        for (i = 1; i < roomcount_max; i++)
        {
           
            Place_room();
        }
       
    }

    void  Place_room()
    {
       
        //  selectedRoom = Random.Range(0, RoomPrefabs.Length);

        if (placedroom[i] == null)
        {
            GetRandomChunk();
            Distance = placedroom[i - 1].GetComponent<Room>().Enter_to_new_room.position.x;
            placedroom[i] = Instantiate(RoomPrefabs[selectedRoom],
                                  placedroom[i - 1].GetComponent<Room>().Enter_to_new_room.position,
                                  transform.rotation);
           
        }
        else
        {

                placedroom[i] = Instantiate(placedroom[i],
                                     placedroom[i - 1].GetComponent<Room>().Enter_to_new_room.position,
                                     transform.rotation);
        }
      
    }
    private void GetRandomChunk()
    {
        List<float> chances = new List<float>();

        for (int x = 0; x < RoomPrefabs.Length; x++)
        {
            for (int r = 0; r < placedroom.Length; r++)
            {
                if (placedroom[r] != null && (RoomPrefabs[x].name + "(Clone)") == placedroom[r].name)
                {
                    room_spawned_amount += 10;
                  
                }
            }
            chances.Add(RoomPrefabs[x].GetComponent<Room>().Chance / (room_spawned_amount));
            room_spawned_amount = 1;
        }

        float value = Random.Range(0, chances.Sum());
      
        float sum = 0;

        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];

            if (value < sum)
            {
                selectedRoom = i; // RoomPrefabs[i];
                break;
            }

        }
   
    }
}
