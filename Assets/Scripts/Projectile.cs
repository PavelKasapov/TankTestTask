using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private static readonly TimeSpan threeSeconds = TimeSpan.FromSeconds(3);

    [SerializeField] Transform selfTransform;
    [SerializeField] float speed = 1f;

    public float damage = 1f;
    public Action OnRelease = delegate { };
    private Coroutine moveCoroutine;

    public float Damage => damage;
    public Vector3 Direction => selfTransform.up;

    public void Launch(Vector3 position, Vector3 direction)
    {
        selfTransform.position = position;

        float angle = Vector3.Angle(Vector3.up, new Vector3(direction.x, direction.y, 0.0f));
        if (direction.x > 0.0f) { angle = -angle; angle += 360; }

        selfTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        moveCoroutine = StartCoroutine(MoveForwardRoutine());
    }

    IEnumerator MoveForwardRoutine()
    {
        var startTime = DateTime.Now;
        while (DateTime.Now - startTime < threeSeconds)
        {
            selfTransform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }

        Release();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<HitTaker>(out var hitTarget))
        {
            hitTarget.TakeDamage(Damage);
        }

        Release();
    }

    private void Release()
    {
        if (isActiveAndEnabled)
        {
            OnRelease.Invoke();
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }
}
