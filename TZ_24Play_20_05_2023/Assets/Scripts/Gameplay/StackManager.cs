using System.Collections;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private GameObject pickUp;
    [SerializeField] private GameObject[] stack;
    [SerializeField] private GameObject stickman;
    [SerializeField] private GameObject addConfetti;

    private CinemachineImpulseSource impulseSource;

    private int maxStackSize = 25;
    private GameObject player;
    private int cubesInStack = 1;
    private bool removing;

    private float wallSurfTime = 0.2f;
    private float fallTime = 0.3f;

    private void Start() {
        stack = new GameObject[maxStackSize];
        stack[0] = transform.GetChild(0).gameObject;
        player = transform.parent.gameObject;
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void AddCube() {
        stickman.GetComponent<Animator>().SetTrigger("Jump");
        cubesInStack++;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f, player.transform.position.z);
        GameObject addedCube = Instantiate(pickUp, new Vector3(player.transform.position.x, 0.5f, player.transform.position.z), Quaternion.identity, transform);
        AddToStack();
        stack[0] = addedCube;

        for(int i = 0; i< transform.childCount-1; i++) {
            stack[i].transform.DOShakeScale(0.5f, 1.03f, 10, 30);
        }

        Instantiate(addConfetti, addedCube.transform.position, Quaternion.identity);
    }

    public void RemoveCube() {
        if(cubesInStack == 1) {
            StopAllCoroutines();
            stickman.GetComponent<RagdollControll>().enabled = true;
            //GameOver();
            GameManager.gameManagerCls.GameOver();           
        }
        else if(!removing) {
            RemoveFromStack();
            cubesInStack--;
            StartCoroutine("WallSurfIE");
        }        
    }

    private IEnumerator WallSurfIE() {
        yield return new WaitForSeconds(wallSurfTime);
        LandStack();
        yield return new WaitForSeconds(fallTime/2.5f);
        impulseSource.GenerateImpulse();
    }

    private void LandStack() {
        for(int i = 0; i<cubesInStack; i++) {    
            stack[i].transform.DOMoveY(i + 0.5f, fallTime).SetEase(Ease.OutBounce);
        }
    }

    private void RemoveFromStack() {
        removing = true;
        for (int i = 0; i < cubesInStack; i++) {
            stack[i] = stack[i + 1];            
        }
        removing = false;
    }

    private void AddToStack() {        
        for (int i = cubesInStack; i > 0; i--) {
            stack[i] = stack[i - 1];            
        }
    }

    private void GameOver() {
        for (int i = 0; i < cubesInStack; i++) {
            Rigidbody rigidbody = stack[i].GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }
    }
}
