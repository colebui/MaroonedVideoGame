using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private const float MAX_ATTACK_DISTANCE = 2F;
    [SerializeField] private const float WAIT_TIME = 3.0f;
    [SerializeField] private const float MIN_SPEED = 0.5f;
    [SerializeField] private const float MAX_SPEED = 7.5f;
    private int NEXT_UPDATE = 3;

    public NavMeshAgent agent;
    
    private PlayerWeaponManager playerRef;

    private Vector3 playerPosition;
    void Start() {
        playerRef = FindObjectOfType<PlayerWeaponManager>();
    }

    void Update() {
        if (Time.time >= NEXT_UPDATE) { 
            NEXT_UPDATE = Mathf.FloorToInt(Time.time) + 1;
            UpdateEveryThreeSecond();
        }

        playerPosition = playerRef.transform.position;
        //if touching
        if (Vector3.Distance(playerPosition, this.agent.transform.position) < MAX_ATTACK_DISTANCE && agent.isStopped == false) {
            UnityEngine.Debug.Log("Agent touches you");
            agent.isStopped = true;
            pauseAgent();
            //todo call attack
        }
        else {
            agent.SetDestination(playerPosition);
        }
    }

    void UpdateEveryThreeSecond() {
        //variable move speed over time with an average of 3.5 speed
        agent.speed = Random.Range(MIN_SPEED, MAX_SPEED);
    }

    IEnumerator AgentTimer() {
        yield return new WaitForSeconds(WAIT_TIME);
        agent.isStopped = false;
    }
    void pauseAgent() {
        StartCoroutine(AgentTimer());
    }

}
