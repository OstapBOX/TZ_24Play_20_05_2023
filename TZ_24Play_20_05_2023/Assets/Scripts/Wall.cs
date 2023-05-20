using UnityEngine;

public class Wall : MonoBehaviour {
    [SerializeField] private GameObject wallCube;

    private int[] wallColumnHeight;

    void Start() {
        wallColumnHeight = new int[GameManager.gameManagerCls.GetWallHeight()];
        GenerateWall();        
    }

    private void GenerateWall() {
        float zSpawnPosition = transform.position.z + transform.localScale.z / 2;
        float xSpawnOffset = transform.localScale.x / 2 - wallCube.transform.localScale.x/2;

        for (int i = 0; i<GameManager.gameManagerCls.GetWallWidth(); i++) {
            GameObject currentCube = Instantiate(wallCube, new Vector3(transform.position.x + i - xSpawnOffset, transform.position.y, zSpawnPosition), Quaternion.identity);
            currentCube.transform.parent = gameObject.transform;           

            for(int j = 1; j< wallColumnHeight.Length; j++) {
                if(Random.Range(0,2) == 1) {
                    wallColumnHeight[i] = j;
                    currentCube =  Instantiate(wallCube, new Vector3(i - xSpawnOffset, transform.position.y + j, zSpawnPosition), Quaternion.identity);
                    currentCube.transform.parent = gameObject.transform;                    
                }
                else {
                    wallColumnHeight[i] = j;
                    break;
                }
            }
        }
    }    
}
