using UnityEngine;

public class RotationCompensator : MonoBehaviour
{
    [SerializeField] private new Transform transform;

    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
