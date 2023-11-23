using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour {
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
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
        if (tower != null)
        {
            TowerMenu.TOWERMENU.SetUpMenu(tower);
            return;
        }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Tower towerToBuild = BuildManager.main.getSelectedTower();
            if (LevelManager.main.spendCurrency(towerToBuild.cost))
            {
                tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
