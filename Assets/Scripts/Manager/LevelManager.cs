using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager main;

    public int currency;

    private void Awake() {
        main = this;
    }

    private void Start() {
        main = this;
        currency = 1000;
    }

    public void increaseCurrency(int amount) {
        currency += amount;
    }

    public bool spendCurrency(int amount) {
        if (amount <= currency) {
            // BUY
            currency -= amount;
            return true;
        }
        else {
            Debug.Log("Not enough money");
            return false;
        }
    }
}
