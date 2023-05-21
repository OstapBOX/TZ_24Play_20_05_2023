using UnityEngine;
using DG.Tweening;

public class MoveHand : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveXPosition;
    void Start()
    {
        Tween();
    }

    private void Tween() {
        transform.DOLocalMoveX(moveXPosition, moveSpeed).SetLoops(999999, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
}
