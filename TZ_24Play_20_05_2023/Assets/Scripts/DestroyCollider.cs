using UnityEngine;

public class DestroyCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        LevelGeneration.LevelGenerationCls.SpawnGround();
    }
}
