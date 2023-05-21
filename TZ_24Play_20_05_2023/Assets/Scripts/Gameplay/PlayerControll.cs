using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

    [SerializeField] private float swipeSpeed;
    [SerializeField] private float extremumSwipeAmount;

    private float lastFrameFingerPositionX;
    private float moveFactorX;
    private float swerveAmount;

    private float bordersPositionX = 2f;
    public float MoveFactorX => moveFactorX;

    private void Update() {
        if (GameManager.gameManagerCls.GetGameState() == GameState.PlayGame) {            

                if (Input.GetMouseButtonDown(0)) {
                    lastFrameFingerPositionX = Input.mousePosition.x;
                }
                else if (Input.GetMouseButton(0)) {
                    moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
                    lastFrameFingerPositionX = Input.mousePosition.x;
                }
                else if (Input.GetMouseButtonUp(0)) {
                    moveFactorX = 0f;
                }


            swerveAmount = Time.deltaTime * swipeSpeed * moveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -extremumSwipeAmount, extremumSwipeAmount);

            if ((transform.position.x <= bordersPositionX && transform.position.x >= - bordersPositionX)) {
                transform.Translate(swerveAmount, 0, 0);
            }
            else {
                if((transform.position.x <= bordersPositionX && swerveAmount > 0) || (transform.position.x >= - bordersPositionX && swerveAmount < 0)) {
                    transform.Translate(swerveAmount, 0, 0);
                }
            }
        }
    }

    
}
