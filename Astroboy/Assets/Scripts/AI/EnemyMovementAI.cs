using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyMovementAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private int radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = 15;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.velocity == Vector3.zero)
            ChangeTargetPosition();
        transform.position = _navMeshAgent.nextPosition;
    }

    private void ChangeTargetPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        Vector3 targetPosition = transform.position + randomDirection;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, radius, 1))
        {
            _navMeshAgent.SetDestination(targetPosition);
        }
    }
}
