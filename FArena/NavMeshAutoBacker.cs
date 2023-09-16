using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshAutoBacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<NavMeshSurface>()?.RemoveData();
        GetComponentInParent<NavMeshSurface>()?.BuildNavMesh();
    }

}
