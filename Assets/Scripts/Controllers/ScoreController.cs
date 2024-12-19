using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI infoText;

    private string infoMessage = "You hit the target!";

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
        infoText.text = infoMessage;
        StartCoroutine(UpdateMessageAfterDelay(2f));
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
        
    }
    IEnumerator UpdateMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        infoText.text = "";
    }
}