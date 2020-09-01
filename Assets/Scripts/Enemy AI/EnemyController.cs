using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float ATTACK_DAMAGE_MAX = 34F;
    [SerializeField] private float ATTACK_DAMAGE_MIN = 20F;
    [SerializeField] private float MAX_ATTACK_DISTANCE = 2F;
    [SerializeField] private float WAIT_TIME = 3.0f;
    [SerializeField] private float MIN_SPEED = 0.5f;
    [SerializeField] private float MAX_SPEED = 7.5f;
    [SerializeField] private int TIME_BETWEEN_ENEMY_SPRINTS = 3;

    public NavMeshAgent agent;
    
    private PlayerHealth playerRef;

    private Vector3 playerPosition;

    // Used for the dodging mechanic
    //private bool playerWithinRange = false;

    void Start() {
        playerRef = FindObjectOfType<PlayerHealth>();
    }

    void Update() {
        if (Time.time >= TIME_BETWEEN_ENEMY_SPRINTS) { 
            TIME_BETWEEN_ENEMY_SPRINTS = Mathf.FloorToInt(Time.time) + 1;
            UpdateEveryThreeSecond();
        }

        playerPosition = playerRef.transform.position;

        //// If player leaves the enemy's range, then start following them again
        //if(playerWithinRange && !(Vector3.Distance(playerPosition, this.agent.transform.position) < MAX_ATTACK_DISTANCE)) {
        //    playerWithinRange = false;
        //    agent.isStopped = false;
        //}

        //if touching
        if (Vector3.Distance(playerPosition, this.agent.transform.position) < MAX_ATTACK_DISTANCE && agent.isStopped == false) {
            UnityEngine.Debug.Log("Agent touches you");
            agent.isStopped = true;
            //playerWithinRange = true;
            pauseAgent();
            // removed dealing damage here to after a delay in the AgentTimer
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
        // Brenden changed this, just to see if it works for a dodge mechanic; deal damage if still in range
        if(Vector3.Distance(playerPosition, this.agent.transform.position) < MAX_ATTACK_DISTANCE) {
            dealDamage();
        }
        agent.isStopped = false;
        //playerWithinRange = false;
    }

    void pauseAgent() {
        StartCoroutine(AgentTimer());
    }

    // TODO: This is going to need to be changed to a hitbox or something to allow for dodges
    void dealDamage() {
        playerRef.TakeDamage(UnityEngine.Random.Range(ATTACK_DAMAGE_MIN, ATTACK_DAMAGE_MAX));
    }
}
