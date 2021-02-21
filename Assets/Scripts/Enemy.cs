using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    // Start is called before the first frame update

    [SerializeField] float speed;
    [SerializeField] float health;
    [SerializeField] float dmgReductionFromArmor;

    public float Speed {
        get => speed;
    }
    public float Health {
        get => health;
    }

    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        float damageDealt = damageDealer.Damage;
        if (!damageDealer.IgnoresArmor) {
            damageDealt -= dmgReductionFromArmor;
        } 
            

        if (damageDealt > 0) {
            health -= damageDealt;
            if (health <= 0) {
                destroyThisEnemy();
            }
        }

        
    }

    public void destroyThisEnemy() {
        Destroy(gameObject);
    }
}
