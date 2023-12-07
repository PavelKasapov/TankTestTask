using System;
using System.Collections;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    private static WaitForFixedUpdate waitForFixedUpdate = new();

    [SerializeField] Cannon[] cannons;
    [SerializeField] new Transform transform;

    private int currentCannonIndex;
    private bool isAttacking;
    private float rotationAxis;

    private Coroutine continiousAttackCoroutine;
    private Coroutine rotateTowerCoroutine;

    private void Start()
    {
        foreach (var cannon in cannons)
        {
            cannon.gameObject.SetActive(false);
        }
        cannons[currentCannonIndex].gameObject.SetActive(true);
    }

    public void ChangeCannon(float next)
    {
        cannons[currentCannonIndex].gameObject.SetActive(false);

        var nextIndex = currentCannonIndex + Math.Sign(next);

        if (nextIndex >= cannons.Length) nextIndex = 0;
        if (nextIndex < 0) nextIndex = cannons.Length - 1;

        cannons[nextIndex].gameObject.SetActive(true);

        currentCannonIndex = nextIndex;
    }

    public void Attack(bool isAttacking)
    {
        this.isAttacking = isAttacking;
        if (continiousAttackCoroutine == null)
        {
            continiousAttackCoroutine = StartCoroutine(ContiniousAttackRoutine());
        }
    }

    IEnumerator ContiniousAttackRoutine()
    {
        while (this.isAttacking)
        {
            cannons[currentCannonIndex].Attack();
            yield return new WaitForSeconds(cannons[currentCannonIndex].delayBetweenShots);
        }
        continiousAttackCoroutine = null;
    }

    public void RotateTower(float axis)
    {
        rotationAxis = -axis;
        if (rotationAxis != 0f && rotateTowerCoroutine == null)
        {
            rotateTowerCoroutine = StartCoroutine(RotateTowerRoutine(axis));
        }
    }

    IEnumerator RotateTowerRoutine(float axis)
    {
        while (rotationAxis != 0f)
        {
            transform.Rotate(90 * rotationAxis * Time.deltaTime * Vector3.forward);
            yield return waitForFixedUpdate;
        }
        rotateTowerCoroutine = null;
    }
}
