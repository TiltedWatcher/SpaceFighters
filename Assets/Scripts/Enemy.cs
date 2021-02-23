using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class EnemySoundEffects{
    [SerializeField] AudioClip audio;
    [SerializeField] [Range(0,1)]float volume;

    public float Volume {
        get => volume;
    }
    public AudioClip Audio {
        get => audio;
    }
}

public class Enemy : MonoBehaviour{
    // Start is called before the first frame update
    [Header("Enemy Combat Values")]
    [SerializeField] protected float speed;
    [SerializeField] protected float health;
    [SerializeField] protected float dmgReductionFromArmor;
    [SerializeField] float minTimeBetweenShots;
    [SerializeField] float maxTimeBetweenShots;
    [SerializeField] float projectileSpeed;
    [SerializeField] protected bool isBoss;

    [Header("Effects")]
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] EnemySoundEffects shootSound;
    [SerializeField] EnemySoundEffects deathSound;


    //states 
    [SerializeField] float shotTimer; //serialized for debugging
    protected bool alive = true;

    //cached elements
    BossLogic thisBoss;

    void Start(){
        if (isBoss) {
            thisBoss = gameObject.GetComponent<BossLogic>();
        } 
        shotTimer = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        
    }

    // Update is called once per frame
    void Update(){
        if (IsBoss) {
            BossCombatOperations();
        }
        ShootAfterCountDown();
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        

        if (other.tag == "Shredder") {
            Debug.Log("Collided with:" + other.tag);
            DestroyThisEnemy();
            return;
        }
        
        if (!damageDealer) {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void BossCombatOperations() {
        Debug.Log("Boss is fighting!");
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
        enemyFire.transform.position = new Vector3(enemyFire.transform.position.x, enemyFire.transform.position.y, 1);
        enemyFire.transform.Rotate(0, 0, 180);
        enemyFire.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound.Audio, Camera.main.transform.position, shootSound.Volume);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        float damageDealt = damageDealer.Damage;

        if (!damageDealer.IgnoresArmor) {
            damageDealt -= dmgReductionFromArmor;
        }

        if (damageDealt > 0) { //don't process damage, if damage was reduced to zero, or a negative number by dmg reduction from armor
            health -= damageDealt;
            if (health <= 0) {
                Death();
            }
        } 
        
    }


    public void DestroyThisEnemy() {
        Debug.Log("Enemy Destroyed");
        alive = false;
        StopCoroutine(bossFight());
        Destroy(gameObject);
    }

    public void Death() {
        alive = false;
        StopCoroutine(bossFight());
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Debug.Log("Enemy destroyed, playing Sound");
        AudioSource.PlayClipAtPoint(deathSound.Audio, Camera.main.transform.position, deathSound.Volume);
        Destroy(gameObject);
        Destroy(explosion, explosionDuration);
    }

    public IEnumerator bossFight() {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        musicPlayer.startBossTrack();
        yield return new WaitWhile(isAlive);
        Debug.Log("Bossfight ending");
        FindObjectOfType<MusicPlayer>().BossBattleHappening = false;
    }

    public bool IsBoss {
        get => isBoss;
    }

    private bool isAlive() {
        return alive;
    }

    public float Speed {
        get => speed;
    }
    public float Health {
        get => health;
    }

    private void OnDestroy() {
        alive = false;
    }
}
