using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

    //Current stats
    //[HideInInspector]
    public float currentHealth;
    //[HideInInspector]
    public float currentRecovery;
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentMight;
    [HideInInspector]
    public float currentProjectileSpeed;
    [HideInInspector]
    public float currentMagnet;


    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap = 100;
    public int experienceCapIncrease;

    #region Current Stats Properties

    [System.Serializable]
    public class LevelRange {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }
    public float CurrentHealth
    {
        get {return currentHealth;}
        set
        {
            if(currentHealth != value)
            {
                currentHealth = value;
                if(GameManager.instance != null)
                {
                    GameManager.instance.currentHealthDisplay.text = "Health " + currentHealth; 
                }
            }
        }
    }
   
    public float CurrentRecovery
    {
        get {return currentRecovery;}
        set
        {
            if(currentRecovery != value)
            {
                currentRecovery = value;
                if(GameManager.instance != null)
                {
                    GameManager.instance.currentRecoveryDisplay.text = "Recovery " + currentRecovery; 
                }
            }
        }
    }

    public float CurrentMoveSpeed
    {
        get {return currentMoveSpeed;}
        set
        {
            if(currentMoveSpeed != value)
            {
                currentMoveSpeed = value;
                if(GameManager.instance != null)
                {
                    GameManager.instance.currentMoveSpeedDisplay.text = "Move Speed " + currentMoveSpeed; 
                }
            }
        }
    }

    public float CurrentMight
    {
        get {return currentMight;}
        set
        {
            if(currentMight != value)
            {
                currentMight = value;
                if(GameManager.instance != null)
                {
                    GameManager.instance.currentMightDisplay.text = "Might " + currentMight; 
                }
            }
        }
    }

    public float CurrentProjectileSpeed
    {
        get {return currentProjectileSpeed;}
        set
        {
            if(currentProjectileSpeed != value)
            {
                currentProjectileSpeed = value;
                if(GameManager.instance != null)
                {
                    GameManager.instance.currentProjectileDisplay.text = "Projectile Speed " + currentProjectileSpeed; 
                }
            }
        }
    }
    #endregion

    [Header("I-Frames")]
    public float invincibilityDuration;
    public float invincibilityTimer;
    public bool isInvincible;

    [Header("UI")]

    public Image healthBar;
    public ParticleSystem damageEffect;
   
    public List<LevelRange> levelRanges;
    InventoryManager inventory;
    public int weaponIndex;
    public int passiveItemIndex;

    public GameObject firstPassiveItemTest, secondPassiveItemTest;
   

    void Awake()
    {

        inventory = GetComponent<InventoryManager>();

        //Assign the variables
        CurrentHealth = characterData.MaxHealth;
        CurrentRecovery = characterData.Recovery;
        CurrentMoveSpeed = characterData.MoveSpeed;
        CurrentMight = characterData.Might;
        CurrentProjectileSpeed = characterData.ProjectileSpeed;
        currentMagnet = characterData.Magnet;

        Spawnweapon(characterData.StartingWeapon);
        //ARMA DOIS
        SpawnPassiveItem(firstPassiveItemTest);
        SpawnPassiveItem(secondPassiveItemTest);
      
    }

    public void IncreaseExperience(int amount){
        experience += amount;

        LevelUpChecker();
    }

    void LevelUpChecker(){
        if (experience >= experienceCap){
            level++;
            experience -= experienceCap;
            experienceCap += experienceCapIncrease;
        }
    }

    void Start()
    {
        GameManager.instance.currentHealthDisplay.text = "Health " + currentHealth;
        GameManager.instance.currentRecoveryDisplay.text = "Recovery " + currentRecovery; 
        GameManager.instance.currentMoveSpeedDisplay.text = "Move Speed " + currentMoveSpeed; 
        GameManager.instance.currentMightDisplay.text = "Might " + currentMight; 
        GameManager.instance.currentProjectileDisplay.text = "Projectile Speed " + currentProjectileSpeed; 

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
        Recover();
    }


    public void Kill()
    {
        if(!GameManager.instance.isGameOver)
        {
            GameManager.instance.GameOver();
        }
    }

    void UpdateHealthBar(){
        healthBar.fillAmount = CurrentHealth / characterData.MaxHealth;
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
    void Recover(){
        if(currentHealth<characterData.MaxHealth){
            currentHealth += currentRecovery * Time.deltaTime;
            // if(currentHealth>characterData.MaxHealth){
            //     currentHealth = characterData.MaxHealth;
            //     }
        }
    }
    public void Spawnweapon(GameObject weapon){
            if (weaponIndex >= inventory.weaponSlots.Count - 1)
            {
            Debug.LogError("Inventory slots already full");
            return;
            }

            GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
            spawnedWeapon.transform.SetParent(transform);

            inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponController>());
            weaponIndex++;
     }
     
     public void SpawnPassiveItem(GameObject passiveItem){
            if (passiveItemIndex >= inventory.passiveItemSlots.Count - 1)
            {
            Debug.LogError("Inventory slots already full");
            return;
            }

            GameObject spawnedPassiveItem= Instantiate(passiveItem, transform.position, Quaternion.identity);
            spawnedPassiveItem.transform.SetParent(transform);

            inventory.AddPassiveItem(passiveItemIndex, spawnedPassiveItem.GetComponent<PassiveItem>());
            passiveItemIndex++;
     }
}
