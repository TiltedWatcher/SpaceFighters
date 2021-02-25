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
    [SerializeField] int amountOfGuaranteedCommonDrops;
    [SerializeField] int amountOfGuaranteedRareDrops;

    [SerializeField] float randomOffsetRange = 5f;

    LootTable lootTable;

    /*   private void OnTriggerEnter2D(Collider2D collision) {
           DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

           if (!damageDealer) {
               return;
           }
           processHitBoss(damageDealer);
       }
    */

    private void Start() {
        var enemy = GetComponent<Enemy>();
        lootTable = enemy.GetLootTable();
    }

    private void OnDestroy() {
        
        for (int i = 0; i < amountOfGuaranteedCommonDrops; i++) {
            var loot = lootTable.dropSpecificRarityLoot("Common");
            placeLoot(loot);
            
        }

        for (int i = 0; i < amountOfGuaranteedRareDrops; i++) {
            var loot = lootTable.dropSpecificRarityLoot("Rare");
            placeLoot(loot);

        }

    }

    private void placeLoot(GameObject loot) {
        var offsetX = Random.Range(-randomOffsetRange, randomOffsetRange);
        var offsetY = Random.Range(-randomOffsetRange, randomOffsetRange);
        var spawnPos = transform.position;
        spawnPos.x += offsetX;
        spawnPos.y += offsetY;
        var spawnedLoot = Instantiate(loot, spawnPos, Quaternion.identity);
    }

}
