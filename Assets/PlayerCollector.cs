using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D playerCollector;

    void Start(){
        player = GetComponent<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }

    void Update(){
        playerCollector.radius = player.currentMagnet;
    }
    void OnTriggerEnter2D(Collider2D col){
   if(col.gameObject.TryGetComponent(out ICellectble collectible))
    {
        collectible.Collect();
    }
    }
}
