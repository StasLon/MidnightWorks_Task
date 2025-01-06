using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DriftScoreDisplay : MonoBehaviour
{
   public TextMeshProUGUI driftScoreText;
   public int DriftScore;
   public PrometeoCarController prometeoCar;
   private float driftScoreUpdateInterval;
   private float driftScoreUpdateTimer;
   [SerializeField] private string textObjectName;

    private void Start()
    {
        if (driftScoreText == null)
        {
            driftScoreText = GameObject.Find(textObjectName)?.transform.GetComponent<TextMeshProUGUI>();
        }
     
    }

    private void Update()
    {
        if (prometeoCar.isDrifting && prometeoCar.useEffects)
        {
            driftScoreUpdateTimer = +Time.deltaTime;
            if (driftScoreUpdateTimer >= driftScoreUpdateInterval)
            {
                IncreaseDriftScore(); 
                driftScoreUpdateTimer = 0f;
            }
        }
    }
    public void IncreaseDriftScore()
    {
        DriftScore++;
        UpdateDriftScoreText();
    }

    public void UpdateDriftScoreText()
    {
        if (driftScoreText != null)
        {
            driftScoreText.text = " " + DriftScore.ToString();
        }
    }
}

