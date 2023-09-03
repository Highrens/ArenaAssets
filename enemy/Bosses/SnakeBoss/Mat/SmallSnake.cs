using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallSnake : MonoBehaviour
{    
    NavMeshAgent agent;
    public Transform target;
    public GameObject player;
    public Transform LookPoint;

    public int snakeLenght;
    public float BodySpeed = 5;
    public int Gap = 10;

    // References
    public GameObject BodyPrefab;
    public GameObject tailPrefab;
    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    // Start is called before the first frame update
 void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        for (int i = 0; i < snakeLenght; i++)
        {
            if (i == snakeLenght - 1)
            {
                GrowSnake(tailPrefab);
            }
            else
            {
                GrowSnake(BodyPrefab);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.timeScale == 0) return;
    agent.destination = target.position;
        // Store position history
        PositionsHistory.Insert(0, transform.position);

        RaycastHit Hit;
        
        if (player && Physics.Raycast(LookPoint.position, player.transform.position - LookPoint.position, out Hit, 300))
        {
            Debug.DrawRay(LookPoint.position, player.transform.position - LookPoint.position, Color.red);
            if (Hit.transform.gameObject.layer == 8)
            {
                agent.speed = 5;
                target.position = player.transform.position;
            }
            else {
                agent.speed = 3;
            }
        }else {
                agent.speed = 3;
        }
        if (GetComponentInChildren<Enemy_Health>().Enemys_health < GetComponentInChildren<Enemy_Health>().Enemys_Max_health * (((float)BodyParts.Count / 10f) - 0.099f)){
            if (BodyParts.Count == 1) {
                 Destroy(BodyParts[0]);
                 BodyParts.RemoveAt(0);
            } else {
                Destroy(BodyParts[BodyParts.Count - 2]);
                BodyParts.RemoveAt(BodyParts.Count - 2);
            }
        }

        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 8) {
            player = other.gameObject;
        }
    }
      private void GrowSnake(GameObject prefab)
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(prefab);
        BodyParts.Add(body);
    }
}
