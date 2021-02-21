using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    // Start is called before the first frame update

    [SerializeField] float speed;
    [SerializeField] float health;
    [SerializeField] float dmgReductionFromArmor;
    [SerializeField] float minTimeBetweenShots;
    [SerializeField] float maxTimeBetweenShots;
    [SerializeField] float projectileSpeed;
    //[SerializeField] bool isDamagedByFriendlyFire;
    [SerializeField] GameObject projectile;


    //states 
    [SerializeField] float shotTimer; //serialized for debugging

    void Start(){
        shotTimer = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update(){
        ShootAfterCountDown();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        
        if (!damageDealer) {
            return;
        }
        ProcessHit(damageDealer);
        
        

    }

    private void ShootAfterCountDown() {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0) {
            Fire();
            shotTimer = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire() {
        GameObject enemyFire = Instantiate(
            projectile, 
            transform.position, 
            Quaternion.identity);
        enemyFire.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        float damageDealt = damageDealer.Damage;

        if (!damageDealer.IgnoresArmor) {
            damageDealt -= dmgReductionFromArmor;
        }

        if (damageDealt > 0) { //don't process damage, if damage was reduced to zero, or a negative number by dmg reduction from armor
            health -= damageDealt;
            if (health <= 0) {
                DestroyThisEnemy();
            }
        } 
        
    }

    public void DestroyThisEnemy() {
        Destroy(gameObject);
    }

    public float Speed {
        get => speed;
    }
    public float Health {
        get => health;
    }
}
