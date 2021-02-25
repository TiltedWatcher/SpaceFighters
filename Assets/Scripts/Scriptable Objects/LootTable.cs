using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LootTable")]
public class LootTable : ScriptableObject{

    [Header("Dropchances")]
    [SerializeField] [Range(0, 100)] float chanceForNoDrop =99.3f;
    [SerializeField] [Range(0, 100)] float chanceForCommonDrop = 0.6f;
    [SerializeField] [Range(0, 100)] float chanceForRareDrop = 0.1f ;
    [SerializeField] [Range(0, 100)] float chanceForEpicDrop = 0;
    [SerializeField] [Range(0, 100)] float chanceForLegendaryDrop = 0;

    [Header("Possible Loot")]
    [SerializeField] List<GameObject> commonDrops ;
    [SerializeField] List<GameObject> rareDrops;
    [SerializeField] List<GameObject> epicDrops;
    [SerializeField] List<GameObject> legendaryDrops;
    //TODO add uncommon Drops


    //states
    float range;


    public GameObject dropLoot() {
        range = chanceForNoDrop + chanceForCommonDrop + chanceForRareDrop + chanceForEpicDrop + chanceForLegendaryDrop;
        string lootRarity = determineLootRarity();
        var loot = dropSpecificRarityLoot(lootRarity);
        return loot;
    }

    private string determineLootRarity() {
        float randomVal = Random.Range(0, range);
        Debug.Log("Random Value is " + randomVal);
        if (randomVal < chanceForLegendaryDrop) {
            return "Legendary";
        } else if (randomVal < chanceForEpicDrop) {
            return "Epic";
        } else if (randomVal < chanceForRareDrop) {
            return "Rare";
        } else if (randomVal < chanceForCommonDrop) {
            return "Common";
        } else {
            return "None";
        }
    
    }

    private GameObject determineItem(List<GameObject> itemList) {
        int indexRange = itemList.Count;

        int index = Random.Range(0,indexRange);

        return itemList[index];
    }

    public GameObject dropSpecificRarityLoot(string lootRarity) {
        GameObject loot = null;
        switch (lootRarity) {

            case "Legendary":
                loot = determineItem(legendaryDrops);
                break;

            case "Epic":
                loot = determineItem(epicDrops);
                break;

            case "Rare":
                loot = determineItem(rareDrops);
                break;

            case "Common":
                loot = determineItem(commonDrops);
                break;
        }

        return loot;
    }

}
