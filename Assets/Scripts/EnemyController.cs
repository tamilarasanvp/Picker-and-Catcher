using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navAi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAi = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            navAi.SetDestination(player.position);
        }
    }
}
