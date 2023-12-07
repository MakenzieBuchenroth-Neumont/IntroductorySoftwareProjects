using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager main;
    [SerializeField] private GameObject EndUI;
    [SerializeField] private TextMeshProUGUI EndText;

    public int currency;
    public int lives;

    private void Awake() {
        main = this;
    }

    private void Start() {
        main = this;
        currency = 200;
        lives = 100;
    }

    public void increaseCurrency(int amount) {
        currency += amount;
    }

    public void decreaseLives(int amount)
    {
        lives -= amount;
        if (lives <= 0)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        if (lives > 0)
        {
            EndUI.SetActive(true);
            EndText.text = "You WIN!!!!";
        }
    }

    public void LoseGame()
    {
        EndUI.SetActive(true);
        EndText.text = "You lost :(";
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
