using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private GameObject pickUp;

    [SerializeField] private GameObject[] stack;
    private int maxStackSize = 100;
    private GameObject player;
    private int cubesInStack = 1;

    private void Start() {
        stack = new GameObject[maxStackSize];
        stack[0] = transform.GetChild(0).gameObject;
        player = transform.parent.gameObject;
    }

    public void AddCube() {
        cubesInStack++;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f, player.transform.position.z);
        GameObject addedCube = Instantiate(pickUp, new Vector3(player.transform.position.x, 0.5f, player.transform.position.z), Quaternion.identity, transform);
        MoveStack();
        stack[0] = addedCube;
    }

    private void MoveStack() {
        for(int i = cubesInStack; i >0; i--) {
            stack[i] = stack[i-1];
        }        
    }
}
