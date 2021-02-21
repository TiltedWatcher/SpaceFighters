using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour{
    // Start is called before the first frame update

    [SerializeField] int damage;
    [SerializeField] bool ignoresArmor;

    public int Damage {
        get => damage;
    }

    public bool IgnoresArmor {
        get => ignoresArmor;
    }

    public void hit() {
        Destroy(gameObject);
    }
}
