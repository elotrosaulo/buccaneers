using Behaviors;
using UnityEngine;
using UnityEngine.AI;


public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent nav;
    private void OnEnable()
    {
        PlayerActionsBehaviour.OnStopLightDamage += StopLight;
    }
        
    private void OnDisable()
    {
        PlayerActionsBehaviour.OnStopLightDamage -= StopLight;
    }
    
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
       
        nav.SetDestination(target.position);
    }

    private void StopLight(bool shouldStop)
    {
        nav.stoppingDistance = shouldStop ? 8f : 0f;
    }
}
