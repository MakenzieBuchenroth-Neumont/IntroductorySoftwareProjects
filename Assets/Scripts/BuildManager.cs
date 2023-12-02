using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower_Shop[] towers;

    private int selectedTower = 0;

    private void Awake() {
        main = this;
    }

    public Tower_Shop getSelectedTower() {
        return towers[selectedTower];
    }

    public void setSelectedTower(int _selectedTower) {
        selectedTower = _selectedTower;
    }
}
