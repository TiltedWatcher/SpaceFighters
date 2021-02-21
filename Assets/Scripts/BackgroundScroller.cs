using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour{
    // Start is called before the first frame update

    [SerializeField] float backgroundScrollSpeed = 0.5f;
    [SerializeField] float starScrollSpeed = 0.2f;
    [SerializeField] GameObject starTemplate;
    [SerializeField] float distanceFromOriginRandomizerX = 10f;
    [SerializeField] float startPosY;
    [SerializeField] float targetPosY;
    [SerializeField] bool hasMovingStarSheet;

    Material backgroundMaterial;
    Vector2 offSet;
    GameObject stars;
    GameObject previousStar;


    void Start(){
        backgroundMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);

        if (starTemplate == null) {
            hasMovingStarSheet = false;
        }

        if (hasMovingStarSheet) {
            float xOffSet = UnityEngine.Random.Range(-distanceFromOriginRandomizerX, distanceFromOriginRandomizerX);
            stars = Instantiate(
                starTemplate,
                new Vector3(xOffSet, startPosY),
                Quaternion.identity);
            previousStar = Instantiate(stars); 
        }
        
    }

    // Update is called once per frame
    void Update(){
        backgroundMaterial.mainTextureOffset += offSet * Time.deltaTime;
        if (hasMovingStarSheet) {
            MoveStars();
        }
        
    }

    private void MoveStars() {
        var movementThisFrame = starScrollSpeed * Time.deltaTime;

        var targetPos = new Vector2(stars.transform.position.x, targetPosY);
        stars.transform.position = Vector2.MoveTowards(stars.transform.position, targetPos, movementThisFrame);

        targetPos = new Vector2(previousStar.transform.position.x, targetPosY + targetPosY);
        previousStar.transform.position = Vector2.MoveTowards(previousStar.transform.position, targetPos, movementThisFrame);

        if (stars.transform.position.y <= targetPosY) {
            Debug.Log("replacing previous Star");
            Destroy(previousStar);
            previousStar = stars;

            float xOffSet = UnityEngine.Random.Range(-distanceFromOriginRandomizerX, distanceFromOriginRandomizerX);
            stars = Instantiate(
                starTemplate,
                new Vector3(xOffSet, startPosY),
                Quaternion.identity);
        }
    }
}
