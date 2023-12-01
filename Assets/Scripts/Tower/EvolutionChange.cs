using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionChange : MonoBehaviour
{
    [SerializeField] private GameObject nextEvolutionPrefab; // Prefab for the next evolution stage
    [SerializeField] public int evolutionLevel = 3; // Levels at which evolution happens
    private TowerTargeting towerTargeting;

    private void Awake()
    {
        towerTargeting = GetComponent<TowerTargeting>();

        if (towerTargeting == null)
        {
            Debug.LogError("TowerTargeting component not found on the GameObject");
        }
    }

    public void Update()
    {
        if (towerTargeting == null)
        {
            Debug.LogError("towerTargeting is still null in Update");
            return;
        }

        if (towerTargeting.level == evolutionLevel)
        {
            Evolve();
        }
    }

    private void Evolve()
    {
        // Instantiate the new evolution prefab
        GameObject newEvolution = Instantiate(nextEvolutionPrefab, transform.position, transform.rotation);

        // Transfer necessary data from the current object to the new one
        TransferDataToNewEvolution(newEvolution);

        // Destroy the current game object
        Destroy(gameObject);
    }

    private void TransferDataToNewEvolution(GameObject newEvolution)
    {
        TowerTargeting newTowerTargeting = newEvolution.GetComponent<TowerTargeting>();
        if (newTowerTargeting != null)
        {
            newTowerTargeting.exp = this.towerTargeting.exp;
            newTowerTargeting.level = this.towerTargeting.level;
            newTowerTargeting.TargetingRangeBase = this.towerTargeting.TargetingRangeBase;
            newTowerTargeting.AttackRateBase = this.towerTargeting.AttackRateBase;
            newTowerTargeting.upgradeCost = this.towerTargeting.upgradeCost;
            newTowerTargeting.eXPUpgradeCost = this.towerTargeting.eXPUpgradeCost;
        }
        else
        {
            Debug.LogError("New evolution does not have TowerTargeting component");
        }
    }

}
