using UnityEngine;
using DG.Tweening;

public class PlusOneMove : MonoBehaviour {
    void Start() {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(new Vector3(0, 10, -5), 5f));
        sequence.OnComplete(() => {
            Destroy(this.gameObject);
        });
    }

}
