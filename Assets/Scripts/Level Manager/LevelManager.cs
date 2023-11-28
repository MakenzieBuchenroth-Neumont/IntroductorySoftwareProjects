using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager main;

    [SerializeField] private GameObject winscreen;

    public int currency;
    public int lives;

    private void Awake() {
        main = this;
    }

    private void Start() {
        currency = 1000;
        lives = 100;
    }

    public void WinGame()
    {
        winscreen.SetActive(true);
    }

    public bool removeLives(int amount)
    {
        lives -= amount;
        if (lives <= 0)
        {
            return false;
        }
        return true;
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
}
