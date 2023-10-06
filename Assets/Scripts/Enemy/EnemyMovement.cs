using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    Transform player;
    public float jumpSpeed;
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    { 

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, jumpSpeed * Time.deltaTime);
       
 
    }
}
