using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SlenderBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    public SkinnedMeshRenderer rend;
    public float scareDistance = 5.0f;
    public float distance;
    public Image noiseEffectImage;
    public GameObject explosion;
    private bool canDamage = true; //Tomar dano
    public static float enemySpeed = 1.5f;
    public static float playerStopView = 20;

    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = 1.5f;
        playerStopView = 20;
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        noiseEffectImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTransform.position);
        distance = Vector3.Distance(playerTransform.position, transform.position);

        if(distance <= scareDistance && canDamage){
            noiseEffectImage.enabled = true;
            playerTransform.GetComponent<PlayerActions>().TakeDamage(1);
            canDamage = false;
        }else if(distance > scareDistance){
            noiseEffectImage.enabled = false;
            canDamage = true;
        }


        if(rend.isVisible && distance <= playerStopView){
            agent.speed = 0;
        }else{
            agent.speed = enemySpeed;
        }

        //agent.speed = rend.isVisible? agent.speed = 0 : agent.speed = 2;
    }

    void OnDestroy() {
        Instantiate(explosion, transform.position, Quaternion.identity);    
    }
}
