using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SnakeController : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform target;
    public Transform[] way;
    public GameObject player;
    public float playerInteresTime;
    float InteresTime;
    public Transform LookPoint;
    public int snakeLenght;
    public float timeToPostion;
    float t;
    int curretPos = 0;
    // Settings
    public float BodySpeed = 5;
    public int Gap = 10;

    // References
    public GameObject BodyPrefab;
    public GameObject tailPrefab;
    public GameObject egg;
    // Lists
    public List<GameObject> BodyParts = new List<GameObject>();
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
                InteresTime = playerInteresTime;
                agent.speed = 7;
                target.position = player.transform.position;
            }
            else
            {
                FolowTheWay();
            }
        }
        else
        {
            FolowTheWay();
        }

        if (GetComponent<Enemy_Health>().Enemys_health < GetComponent<Enemy_Health>().Enemys_Max_health * (((float)BodyParts.Count / 10f) - 0.1f))
        {
            if (BodyParts.Count == 1)
            {
                Destroy(BodyParts[0]);
                BodyParts.RemoveAt(0);
            }
            else
            {
                Destroy(BodyParts[BodyParts.Count - 2]);
                BodyParts.RemoveAt(BodyParts.Count - 2);
            }
        }

        // Move body parts
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

    void FolowTheWay()
    {
        InteresTime -= Time.deltaTime;
        if (InteresTime <= 0)
        {
            agent.speed = 5;
            t += Time.deltaTime;
            if (t > timeToPostion)
            {
                if (GetComponent<Enemy_Health>().Enemys_health < GetComponent<Enemy_Health>().Enemys_Max_health / 2)
                {
                    int i = Random.Range(0, 100);
                    if (i > 50) Instantiate(egg, transform.position, transform.rotation);
                }

                t = 0;
                curretPos++;
                if (curretPos >= way.Length)
                {
                    curretPos = 0;
                }
            }
            target.position = way[curretPos].position;
        }
    }

    private void GrowSnake(GameObject prefab)
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(prefab);
        BodyParts.Add(body);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            player = other.gameObject;
        }
    }
}