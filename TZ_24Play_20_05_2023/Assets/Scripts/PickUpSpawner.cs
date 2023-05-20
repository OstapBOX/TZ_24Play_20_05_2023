using UnityEngine;

public class PickUpSpawner : MonoBehaviour {
    [SerializeField] private GameObject pickUpCube;

    private int halfSlotsAmountPerPlatform = 3;
    private float[] slotsZPositions;

    private float spawnProbability = 222f;

    private void Start() {
        slotsZPositions = new float[halfSlotsAmountPerPlatform * 2];
        CalculateSlotsPositions();
        SpawnPickUps();
    }

    private void SpawnPickUps() {
        for (int i = 0; i < halfSlotsAmountPerPlatform * 2; i++) {
            if (Random.Range(0, 100) <= spawnProbability) {
                GameObject currentPickUp = Instantiate(pickUpCube, new Vector3(RandomXPosition(), 0.5f, slotsZPositions[i]), Quaternion.identity);
                currentPickUp.transform.parent = gameObject.transform;
            }
        }
    }

    private float RandomXPosition() {
        return Random.Range(0, GameManager.gameManagerCls.GetWallWidth()) - GameManager.gameManagerCls.GetWallWidth() / 2;
    }

    private void CalculateSlotsPositions() {
        float edgePlatformZOffset = 1.5f;
        float halfPlatformSize = transform.localScale.z / 2;
        float spawnInterwals = (halfPlatformSize - edgePlatformZOffset) / halfSlotsAmountPerPlatform;

        for (int i = 0; i < halfSlotsAmountPerPlatform; i++) {
            slotsZPositions[i] =   edgePlatformZOffset * 2 + spawnInterwals * i + transform.position.z;
        }
        for (int i = halfSlotsAmountPerPlatform + 1; i < halfSlotsAmountPerPlatform * 2; i++) {
            slotsZPositions[i] =   edgePlatformZOffset * 4 + spawnInterwals * i + transform.position.z;
        }
    }

}
