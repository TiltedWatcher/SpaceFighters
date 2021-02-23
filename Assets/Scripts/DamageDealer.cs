using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour{
    // Start is called before the first frame update

    [SerializeField] int damage;
    [SerializeField] bool ignoresArmor;
    //[SerializeField] float speed = 0; //the speed at which the projectile moves. If thise is not a projectile, leave at 0 

    public int Damage {
        get => damage;
    }

    public bool IgnoresArmor {
        get => ignoresArmor;
    }

    public void buffDamage(int buff) {
        damage +=buff;
    }

    public void hit() {
        Destroy(gameObject);
    }
}
