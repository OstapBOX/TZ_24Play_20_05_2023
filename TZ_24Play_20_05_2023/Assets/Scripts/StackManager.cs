using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    [SerializeField] private GameObject pickUp;
    [SerializeField] private GameObject[] stack;

    private int maxStackSize = 25;
    private GameObject player;
    private int cubesInStack = 1;
    private float wallSurfTime = 0.2f;
    private float fallTime = 0.3f;

    private void Start() {
        stack = new GameObject[maxStackSize];
        stack[0] = transform.GetChild(0).gameObject;
        player = transform.parent.gameObject;
    }

    public void AddCube() {
        cubesInStack++;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f, player.transform.position.z);
        GameObject addedCube = Instantiate(pickUp, new Vector3(player.transform.position.x, 0.5f, player.transform.position.z), Quaternion.identity, transform);
        AddToStack();
        stack[0] = addedCube;
    }

    public void RemoveCube() {
        RemoveFromStack();
        cubesInStack--;
        StartCoroutine(WallSurfIE());
    }

    private IEnumerator WallSurfIE() {
        yield return new WaitForSeconds(wallSurfTime);
        LandStack();
    }

    private void LandStack() {
        for(int i = 0; i<cubesInStack; i++) {            
            stack[i].transform.DOMoveY(i + 0.5f, fallTime).SetEase(Ease.OutBounce);
        }
    }

    private void RemoveFromStack() {
        for (int i = 0; i < cubesInStack; i++) {
            stack[i] = stack[i + 1];            
        }       
    }

    private void AddToStack() {
        for (int i = cubesInStack; i > 0; i--) {
            stack[i] = stack[i - 1];
        }
    }
}
