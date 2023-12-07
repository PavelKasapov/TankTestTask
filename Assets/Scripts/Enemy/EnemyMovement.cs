using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
    private static int[] agentTypeIDs;

    [SerializeField] NavMeshAgent agent;

    [Inject] EnemyMovementSystem enemyMovementSystem;

    private void Awake()
    {
        if (agentTypeIDs == null)
        {
            var settingsCount = NavMesh.GetSettingsCount();
            agentTypeIDs = new int[settingsCount];
            for (int i = 0; i < settingsCount; i++)
            {
                agentTypeIDs[i] = NavMesh.GetSettingsByIndex(i).agentTypeID;
            }
        }
    }

    void OnEnable()
    {
        agent.isStopped = false;
        enemyMovementSystem.AddAgent(agent);
    }

    void OnDisable()
    {
        agent.isStopped = true;
        enemyMovementSystem.RemoveAgent(agent);
    }

    public void InitParams(float speed, float hp)
    {
        switch (hp)
        {
            case float n when (n < 75f):
                agent.agentTypeID = agentTypeIDs[0];
                break;

            case float n when (n >= 75f && n <= 150f):
                agent.agentTypeID = agentTypeIDs[1];
                break;

            case float n when (n > 150f):
                agent.agentTypeID = agentTypeIDs[2];
                break;
        }

        agent.speed = speed;
    }
}
