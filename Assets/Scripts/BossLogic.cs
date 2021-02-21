using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BossWeapon {
    [SerializeField] GameObject projectile;
    [SerializeField] float weaponCooldownMin;
    [SerializeField] float weaponCooldownMax;

    public GameObject Projectile {
        get => projectile;
    }
    public float WeaponCooldownMin {
        get => weaponCooldownMin;
    }
    public float WeaponCooldownMax {
        get => weaponCooldownMax;
    }
}

public class BossLogic : MonoBehaviour{

    [SerializeField] BossWeapon[] bossWeapons;

    /*   private void OnTriggerEnter2D(Collider2D collision) {
           DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

           if (!damageDealer) {
               return;
           }
           processHitBoss(damageDealer);
       }
    */




}
