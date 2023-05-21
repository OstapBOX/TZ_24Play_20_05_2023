using UnityEngine;
using DG.Tweening;

public class PickUp : MonoBehaviour
{
    [SerializeField] private bool inHolder;

    private StackManager stackManager;

    private void Start() {
        stackManager = GameObject.Find("CubeHolder").GetComponent<StackManager>();    
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("PickUp") && collision.gameObject.GetComponent<PickUp>().inHolder && !inHolder) {
            SetInHolderState(true);
            stackManager.AddCube();
            Destroy(gameObject);

        }else if (collision.gameObject.CompareTag("Wall")) {
            GetComponent<Collider>().enabled = false;
            transform.parent = collision.gameObject.transform;
            SetInHolderState(false);
            stackManager.RemoveCube();                
        }
    }

    public void SetInHolderState(bool _inHolder) {
        inHolder = _inHolder;
    }

}
