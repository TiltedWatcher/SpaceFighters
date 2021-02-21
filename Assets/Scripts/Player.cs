using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    //parameters
    [Header("Weapons")]
    [SerializeField] GameObject playerLaserPrefab;
    [SerializeField] float projectileSpeedPlayer = 10f;
    [SerializeField] float projectileFireRecoveryTime = 0.1f;

    [Header("Player Movement")]
    [SerializeField] float playerMoveSpeed;
    [SerializeField] float playSpacePaddingY;
    [SerializeField] float playSpacePaddingX;

    [Header("Player Stats")]
    [SerializeField] int playerHealth;
    [SerializeField] bool isInvincible;
    [SerializeField] int damageReduction;
    [SerializeField] int extraLifes;

    //the edges of the playspace.
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    //states
    bool repeatFireIsActive = false;
    float remainingHealth;

    Coroutine repeatFireCor;

    // Start is called before the first frame update
    void Start(){
        createPlaySpaceBoundaries();
        remainingHealth = playerHealth;
    }


    // Update is called once per frame
    void Update(){
        move();
        Fire();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) {
            return;
        }
        processHit(damageDealer);
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1") && !repeatFireIsActive) {
            repeatFireCor = StartCoroutine(fireContinuously());
        }
        if (Input.GetButtonUp("Fire1") && repeatFireIsActive) {
            StopCoroutine(repeatFireCor);
            repeatFireIsActive = false;
        }
    }

    private IEnumerator fireContinuously() {
        while (true) {
            repeatFireIsActive = true;
            GameObject laser = Instantiate(
                playerLaserPrefab,
                transform.position,
                Quaternion.identity) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeedPlayer);

            yield return new WaitForSeconds(projectileFireRecoveryTime); 
        }
    }

    private void move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed;
        
        var newXPos = Mathf.Clamp(
            transform.position.x + deltaX,
            xMin, xMax);
        var newYPos = Mathf.Clamp(
            transform.position.y + deltaY,
            yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
      
    }

    private void processHit(DamageDealer damageDealer) {
        if (isInvincible) {
            damageDealer.hit();
            return;
        }

        float damageDealt = damageDealer.Damage;

        if (!damageDealer.IgnoresArmor) {
            damageDealt -= damageReduction;
        }

        if (damageDealt > 0) {
            remainingHealth -= damageDealt;
            Debug.Log("Health remaining: " + remainingHealth);

            if (remainingHealth <= 0) {
                playerDeath();
            }
            
        }
        damageDealer.hit();
        
    }

    private void playerDeath() {
        Destroy(gameObject);
    
    }


    private void createPlaySpaceBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playSpacePaddingX;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playSpacePaddingX;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playSpacePaddingX; //adding X padding here, since it's about not having the player disappear of the bottom of the Map. Y padding only pads towards the top
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playSpacePaddingY;
       
    }
}
