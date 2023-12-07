using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly static WaitForFixedUpdate waitForFixedUpdate = new();

    [SerializeField] float speed;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] new Transform transform;

    private Vector2 moveValue;
    private Coroutine moveCoroutine;

    public void InitParams(float speed)
    {
        this.speed = speed;
    }

    public void Move(Vector2 value)
    {
        moveValue = value;

        if (value != Vector2.zero && moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(VelocityRoutine());
        }
    }

    IEnumerator VelocityRoutine()
    {
        while (moveValue != Vector2.zero)
        {
            if (moveValue.y != 0f)
                rigidbody.velocity = speed * moveValue.y * transform.up;

            rigidbody.AddTorque(-speed / 2 * moveValue.x * Mathf.Sign(moveValue.y));
            yield return waitForFixedUpdate;
        }
        moveCoroutine = null;
    }
}
