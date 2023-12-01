using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;

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
    [SerializeField] private EvolutionChange evolutionChange;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 2.0f;
    [SerializeField] private float attackRate = 1.0f; // 1 shot per second
    [SerializeField] public int upgradeCost = 100;
    [SerializeField] public int eXPUpgradeCost = 100;
    [SerializeField] public int level = 1;
    [SerializeField] public int exp = 0;

    public float TargetingRangeBase;
    public float AttackRateBase;

    private Transform target;
    private float attackTimer = 0.0f;


    public float Angle;

    // Start is called before the first frame update
    void Start()
    {
        TargetingRangeBase = targetingRange;
        AttackRateBase = attackRate;

        FindTarget();

        if (spriteChange == null)
        {
            Debug.LogError("SpriteChange component is not assigned.");
        }

        // Check and assign upgradeButton
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(Upgrade);
        }
        else
        {
            Debug.LogError("Upgrade Button is not assigned.");
        }

        // Initialize evolutionChange if not assigned
        if (evolutionChange == null)
        {
            evolutionChange = GetComponent<EvolutionChange>();
            if (evolutionChange == null)
            {
                Debug.LogError("EvolutionChange component is not assigned or not found.");
            }
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
        if (CalculateCost() > LevelManager.main.currency && CalculateEXPCost() > this.exp)
        {

            LevelManager.main.spendCurrency(CalculateCost());

            level++;
            if (evolutionChange.evolutionLevel < 2)
            {
                evolutionChange.evolutionLevel++;
            }

            targetingRange = CalculateRange();
            attackRate = CalculateAttackRate();

            CloseUpgradeUI();
            Debug.Log("Upgraded to level " + level);
            Debug.Log("New range: " + targetingRange);
            Debug.Log("New attack rate: " + attackRate);
            Debug.Log("New cost: " + CalculateCost());
        }
        else if (CalculateCost() > LevelManager.main.currency)
        {
            Debug.Log("Not enough money to upgrade.");
        }
        else if (CalculateEXPCost() > this.exp)
        {
            Debug.Log("Not enough EXP to upgrade.");
        }
    }

    private int CalculateCost()
    {
        return Mathf.RoundToInt(upgradeCost * Mathf.Pow(level, 0.8f));
    }

    private int CalculateEXPCost()
    {
        return Mathf.RoundToInt(eXPUpgradeCost * Mathf.Pow(level, 0.8f));
    }

    public void increaseExp(int amount)
    {
        exp += amount;
    }

    public bool spendExp(int amount)
    {
        if (amount <= exp)
        {
            // BUY
            exp -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough exp");
            return false;
        }
    }

    private float CalculateRange()
    {
        return TargetingRangeBase * Mathf.Pow(level, 0.4f);
    }

    private float CalculateAttackRate()
    {
        return AttackRateBase * Mathf.Pow(level, 0.6f);
    }
}
