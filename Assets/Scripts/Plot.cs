using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour {
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    public GameObject towerObj;
    public TowerTargeting towerTargeting;
    private Color startColor;

    private void Start() {
        startColor = sr.color;
    }

    private void OnMouseEnter() {
        sr.color = hoverColor;
    }

    private void OnMouseExit() {
        sr.color = startColor;
    }
    private void OnMouseDown() {
        if (UIManager.main.IsHoveringUI()) return;

        if (towerObj != null)
        {
            towerTargeting.OpenUpgradeUI();
            return;
        }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Tower_Shop towerToBuild = BuildManager.main.getSelectedTower();
            if (LevelManager.main.spendCurrency(towerToBuild.cost))
            {
                towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
                towerTargeting = towerObj.GetComponent<TowerTargeting>();
                towerTargeting.SetPlot(this);
            }
        }
    }
}
