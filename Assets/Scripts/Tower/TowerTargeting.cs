using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TowerTargeting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 2.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float attackRate = 1.0f; // 1 shot per second

    private SpriteRenderer spriteRenderer;

    private Transform target = null;
    private float attackTimer = 0.0f;

    private float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        FindTarget();
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= 1.0f / attackRate)
            {
                Attack();
                attackTimer = 0.0f;
            }
        }
    }

    private void Attack()
    {
        Debug.Log("Attacked");
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 0.0f, enemyMask);

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
        return Vector2.Distance(transform.position, target.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90.0f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));
        towerRotationPoint.rotation = Quaternion.RotateTowards(towerRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }



    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
