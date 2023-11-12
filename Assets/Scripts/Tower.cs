using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5.0f;
    //[SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private Sprite[] spriteArray;

    private SpriteRenderer spriteRenderer;

    // make array of sprites

    private Transform target = null;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();
        ChangeSprite();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 0.0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(transform.position, target.position) <= targetingRange;
    }

    private float angle = 0.0f;
    private void RotateTowardsTarget()
    {
        angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90.0f;

        //Quaternion targetRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));
        //towerRotationPoint.rotation = Quaternion.RotateTowards(towerRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void ChangeSprite()
    {
        // change sprite based on angle for 8 directions
        if (angle >= 0 && angle < 45)
            spriteRenderer.sprite = spriteArray[0];
        else if (angle >= 45 && angle < 90)
            spriteRenderer.sprite = spriteArray[1];
        else if (angle >= 90 && angle < 135)
            spriteRenderer.sprite = spriteArray[2];
        else if (angle >= 135 && angle < 180)
            spriteRenderer.sprite = spriteArray[3];
        else if (angle >= 180 && angle < 225)
            spriteRenderer.sprite = spriteArray[4];
        else if (angle >= 225 && angle < 270)
            spriteRenderer.sprite = spriteArray[5];
        else if (angle >= 270 && angle < 315)
            spriteRenderer.sprite = spriteArray[6];
        else if (angle >= 315 && angle < 360)
            spriteRenderer.sprite = spriteArray[7];
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    // Start is called before the first frame update
}
