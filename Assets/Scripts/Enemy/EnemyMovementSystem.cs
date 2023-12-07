using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyMovementSystem : MonoBehaviour
{
    [Inject(Id = "PlayerTransform")] Transform playerTransform;

    private readonly WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    private List<NavMeshAgent> navMeshAgents = new List<NavMeshAgent>();

    private Coroutine movementCoroutine;

    public void AddAgent(NavMeshAgent agent)
    {
        navMeshAgents.Add(agent);
        agent.SetDestination(playerTransform.position);

        movementCoroutine ??= StartCoroutine(MovementRoutine());
    }

    public void RemoveAgent(NavMeshAgent agent)
    {
        navMeshAgents.Remove(agent);
    }

    IEnumerator MovementRoutine()
    {
        while (navMeshAgents.Count > 0)
        {
            foreach (NavMeshAgent agent in navMeshAgents.ToList())
            {
                if (agent.isActiveAndEnabled)
                {
                    agent.SetDestination(playerTransform.position);
                    yield return waitForFixedUpdate;
                }
            }
            yield return waitForFixedUpdate;
        }
        movementCoroutine = null;
    }
}
