using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private SpriteChange spriteChange; // Make sure to assign this in the Inspector

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 2.0f;
    [SerializeField] private float attackRate = 1.0f; // 1 shot per second

    private Transform target;
    private float attackTimer = 0.0f;

    public float Angle;

    // Start is called before the first frame update
    void Start()
    {
        FindTarget();
        if (spriteChange == null)
        {
            Debug.LogError("SpriteChange component is not assigned.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
            return;
        }

        // Calculate the angle to the target
        CalculateAngleToTarget();

        // Change the sprite based on the angle
        spriteChange.ChangeSpriteBasedOnAngle(Angle);

        attackTimer += Time.deltaTime;
        if (attackTimer >= 1.0f / attackRate)
        {
            Attack();
            attackTimer = 0.0f;
        }
    }

    private void Attack()
    {
        Debug.Log("Attacked");
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0.0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
            Debug.Log("Target found: " + target.name);
        }
        else
        {
            Debug.Log("No target found.");
        }
    }

    private bool CheckTargetIsInRange()
    {
        return target != null && Vector2.Distance(transform.position, target.position) <= targetingRange;
    }

    private void CalculateAngleToTarget()
    {
        Angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Angle = (Angle - 360) % 360; // Normalize angle to be within 0-360 degrees
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
