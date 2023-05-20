using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public static LevelGeneration LevelGenerationCls;

    [SerializeField] private GameObject roadPart;

    private int startRoadLenght = 4;
    private int roadOffset;

    private void Start() {
        LevelGenerationCls = this;
        SetRoadOffset();
        SpawnOnStart();        
    }

    private void SpawnOnStart() {
        for(int i = 0; i < startRoadLenght; i++) {
           GameObject currentRoad = Instantiate(roadPart, new Vector3(roadPart.transform.position.x, roadPart.transform.position.y, roadPart.transform.position.z + (i * roadOffset)), 
                        Quaternion.identity, transform);
            if(i == 0) {
                currentRoad.GetComponent<Wall>().enabled = false;
                currentRoad.GetComponent<PickUpSpawner>().enabled = false;
            }
        }
    }

    public void SpawnGround() {
        Instantiate(roadPart, new Vector3(roadPart.transform.position.x, roadPart.transform.position.y, roadPart.transform.position.z + ((startRoadLenght -1) * roadOffset)),
                       Quaternion.identity, transform);
    }

    private void SetRoadOffset() {
        roadOffset = (int)roadPart.transform.localScale.z;
    }

}
