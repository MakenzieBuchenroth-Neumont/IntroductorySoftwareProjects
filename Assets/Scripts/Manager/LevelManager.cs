using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager main;

    public int currency;
    public int exp;

    private void Awake() {
        main = this;
    }

    private void Start() {
        main = this;
        currency = 1000;
        exp = 0;
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
            Debug.Log("Can't afford");
            return false;
        }
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
            Debug.Log("Can't afford");
            return false;
        }
    }
}
