using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControll : MonoBehaviour {
    private Rigidbody[] allRigidbodies;
    private Transform[] allChilds;
    private Animator animator;

    int rigidBodiesAmount = 0;

    private void Start() {
        animator = this.gameObject.GetComponent<Animator>();
        FindRigidBodies();       
    }

    public void MakePhysical() {
        animator.enabled = false;
        for(int i = 0; i< rigidBodiesAmount; i++) {
            allRigidbodies[i].isKinematic = false;
        }
    }

    private void FindRigidBodies() {
        allChilds = this.transform.gameObject.GetComponentsInChildren<Transform>();
        allRigidbodies = new Rigidbody[allChilds.Length];

        for (int i = 0; i < allChilds.Length; i++) {
            if (allChilds[i].GetComponent<Rigidbody>() != null) {
                allRigidbodies[rigidBodiesAmount] = allChilds[i].GetComponent<Rigidbody>();
                rigidBodiesAmount++;
            }
        }
    }
    
}
