using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

    //Current stats
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentRecovery;
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentMight;
    [HideInInspector]
    public float currentProjectileSpeed;

    [Header("I-Frames")]
    public float invincibilityDuration;
    public float invincibilityTimer;
    public bool isInvincible;

    [Header("UI")]

    public Image healthBar;

    public ParticleSystem damageEffect;
    
    void Awake()
    {
        //Assign the variables
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }

    void Update()
    {
        if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            isInvincible = false;
        }
    }

    // public void TakeDamage(float dmg)
    // {
    //     if(!isInvincible)
    //     {
    //         currentHealth -= dmg;

    //         invincibilityTimer = invincibilityDuration;
    //         isInvincible = true;

    //         if(currentHealth <= 0)
    //         {
    //             Kill();
    //         }
    //         UpdateHealthBar();
    //     }
    // }

    public void Kill()
    {
        Debug.Log("VOCE MORREU");
    }

    void UpdateHealthBar(){
        healthBar.fillAmount = currentHealth / characterData.MaxHealth;
    }

    public void TakeDamage(float dmg){

    if (!isInvincible){
    currentHealth -= dmg;

    if (damageEffect) Instantiate(damageEffect, transform.position, Quaternion.identity);
    invincibilityTimer = invincibilityDuration;
    isInvincible = true;

    if (currentHealth <= 0){
    Kill();
    }

    UpdateHealthBar();
    }
    }


}
