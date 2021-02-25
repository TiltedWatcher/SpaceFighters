using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour{

    protected Player player;
    [SerializeField] protected float despawnTimer;
    [SerializeField] protected bool willDespawnAfterTimer;

    public PowerUp() {
        willDespawnAfterTimer = false;
    }

    public PowerUp(float despawnTimer) {
        this.despawnTimer = despawnTimer;
    }

    // Start is called before the first frame update
    private void Start() {
        if (willDespawnAfterTimer) {
            StartCoroutine(startDespawnTimer());
        }
    }
    public virtual void ProcessPowerUp(Player player) {

    }

    public IEnumerator startDespawnTimer() {
        Debug.Log("Despawning soon");
        yield return new WaitForSeconds(despawnTimer);
        Destroy(gameObject);

    }


}
