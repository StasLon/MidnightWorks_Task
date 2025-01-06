using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI secondMoneyText;
    public TextMeshProUGUI victoryDriftText;

    public Button doubleMoneyButton;
    public GameObject victoryScreen;

    private float timeRemaining = 120f;
    private int driftPointsEarned = 0;
    public int money = 0;

    private bool isTimeRunning;
    private bool isGameStarted = false;
    private bool isDoubleMoneyUsed = false;

    public PrometeoCarController carControllerPrometero;
    public DriftScoreDisplay driftScoreScript;
    

    private IEnumerator  Start()
    {
        yield return new WaitForSeconds(0.5f);
        carControllerPrometero = FindAnyObjectByType<PrometeoCarController>();
        driftScoreScript = FindAnyObjectByType<DriftScoreDisplay>();
        isGameStarted = true;
        victoryScreen.SetActive(false);
        isTimeRunning = true;
        money = PlayerPrefs.GetInt("Money", 0);
        UpdateMoneyText();
        driftScoreScript.UpdateDriftScoreText();
    }

    private void Update()
    {
        if (!isGameStarted)
            return;
        
        if (isTimeRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                isTimeRunning = false;
                ShowVictoryScreen();
                ConvertDriftScoreToMoney();
                victoryDriftText.text = " " + driftScoreScript.DriftScore;
                secondMoneyText.text = $"Money: {money}";
                UpdateVictoryMoneyText();
                UpdateDriftVictoryText(); 
            }
        }
    }

    private void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        carControllerPrometero.enabled = false;
        driftPointsEarned = driftScoreScript.DriftScore; 
        victoryDriftText.text = "Drift Points: " + driftPointsEarned; 
        secondMoneyText.text = $"Money: {money}";
    }

    private void UpdateTimerText()
    {
        timerText.text = Mathf.FloorToInt(timeRemaining).ToString();
    }

    public void DoubleMoney()
    {
        if (isDoubleMoneyUsed) return;
        money += driftPointsEarned;
        isDoubleMoneyUsed = true;
        UpdateMoneyText();
        UpdateVictoryMoneyText();
        doubleMoneyButton.enabled = false;

        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();
    }

    private void ConvertDriftScoreToMoney()
    {
        money += driftScoreScript.DriftScore;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();
        driftScoreScript.UpdateDriftScoreText();
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = " " + money;
    }

    private void UpdateVictoryMoneyText()
    {
        secondMoneyText.text = " " + money;
    }

    private void UpdateDriftVictoryText()
    {
        victoryDriftText.text = " " + driftScoreScript.DriftScore;
    }

    public void MenuScene()
    {
        driftScoreScript.DriftScore = 0;
        driftScoreScript.UpdateDriftScoreText();
        SceneManager.LoadScene("Menu");
    }

}
