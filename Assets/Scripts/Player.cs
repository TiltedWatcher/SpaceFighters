using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    //parameters
    [SerializeField] ModifiableParameters gameParameters;
    [SerializeField] GameObject playerLaserPrefab;

    //the edges of the playspace.
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start(){
        createPlaySpaceBoundaries();
        StartCoroutine(testCoroutine());
        
    }

    private IEnumerator testCoroutine() {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(3);
        Debug.Log("Coroutine finished yielding");
    }

    // Update is called once per frame
    void Update(){
        move();
        Fire();
        
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            
            GameObject laser = Instantiate(
                playerLaserPrefab, 
                transform.position, 
                Quaternion.identity) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameParameters.ProjectileSpeedPlayer);

        }
    }

    private void move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * gameParameters.PlayerMoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * gameParameters.PlayerMoveSpeed;
        
        var newXPos = Mathf.Clamp(
            transform.position.x + deltaX,
            xMin, xMax);
        var newYPos = Mathf.Clamp(
            transform.position.y + deltaY,
            yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
      
    }

    private void createPlaySpaceBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + gameParameters.PlaySpacePaddingX;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - gameParameters.PlaySpacePaddingX;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + gameParameters.PlaySpacePaddingX; //adding X padding here, since it's about not having the player disappear of the bottom of the Map. Y padding only pads towards the top
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - gameParameters.PlaySpacePaddingY;
        Debug.Log(gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);
        Debug.Log(gameParameters.PlaySpacePaddingY);
        Debug.Log("min " + yMin + ", max " + yMax);
        Debug.Log("min " + xMin + ", max " + xMax);
    }
}
