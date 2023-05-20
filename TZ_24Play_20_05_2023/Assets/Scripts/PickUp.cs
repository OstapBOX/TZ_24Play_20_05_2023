using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private bool inHolder;
    private StackManager stackManager;

    private void Start() {
        stackManager = GameObject.Find("CubeHolder").GetComponent<StackManager>();    
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("PickUp") && !collision.gameObject.GetComponent<PickUp>().inHolder) {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            stackManager.AddCube();
            Debug.Log("Touched " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Wall")) {


            Debug.Log("Touched " + collision.gameObject.name);
        }
    }

    public void SetInHolderState(bool _inHolder) {
        inHolder = _inHolder;
    }
}
