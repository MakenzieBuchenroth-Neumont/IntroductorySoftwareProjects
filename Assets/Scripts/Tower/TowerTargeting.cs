using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class TowerTargeting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private SpriteChange spriteChange; // Make sure to assign this in the Inspector
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 2.0f;
    [SerializeField] private float attackRate = 1.0f; // 1 shot per second
    [SerializeField] private int baseUpgradeCost = 100;

    private float targetingRangeBase;
    private float attackRateBase;

    private Transform target;
    private float attackTimer = 0.0f;

    private int level = 1;

    public float Angle;

    // Start is called before the first frame update
    void Start()
    {
        targetingRangeBase = targetingRange;
        attackRateBase = attackRate;

        FindTarget();
        if (spriteChange == null)
        {
            Debug.LogError("SpriteChange component is not assigned.");
        }

        upgradeButton.onClick.AddListener(Upgrade);
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

    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
        UIManager.main.SetHoveringState(false);
    }

    public void Upgrade()
    {
        if (CalculateCost() > LevelManager.main.currency) return;

        LevelManager.main.spendCurrency(CalculateCost());

        level++;

        targetingRange = CalculateRange();
        attackRate = CalculateAttackRate();

        CloseUpgradeUI();
        Debug.Log("Upgraded to level " + level);
        Debug.Log("New range: " + targetingRange);
        Debug.Log("New attack rate: " + attackRate);
        Debug.Log("New cost: " + CalculateCost());
    }

    private int CalculateCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(level, 0.8f));
    }

    private float CalculateRange()
    {
        return targetingRangeBase * Mathf.Pow(level, 0.4f);
    }

    private float CalculateAttackRate()
    {
        return attackRateBase * Mathf.Pow(level, 0.6f);
    }
}
