using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameOverHandler : MonoBehaviour
{

[SerializeField] private GameObject player;
[SerializeField] private Button continueButton;
[SerializeField] private GameObject gameOverDisplay;
[SerializeField] private GameObject scoreDisplay;
[SerializeField] private AstroidSpawner astroidSpawner;
[SerializeField] TextMeshProUGUI scoreText;
[SerializeField] TextMeshProUGUI finalScoreText;

[SerializeField] float scoreMultiplier = 1f;
bool gameOver = false;
private float score;



public void EndGame()
{
astroidSpawner.enabled = false;
scoreDisplay.gameObject.SetActive(false);
gameOverDisplay.gameObject.SetActive(true);
gameOver = true;
finalScoreText.text = "Your final score was: " + Mathf.FloorToInt(score).ToString();

}

public void StartScore()
{
  gameOver = false;
}

public void LoadMenu()
{

SceneManager.LoadScene(0);

}

public void ReloadGame()
{

SceneManager.LoadScene(1);

}

public void ContinueButton()
{

AdManager.Instance.ShowAd(this);
continueButton.interactable = false;

}

void Update()
{
if(!gameOver)
{
UpdateScore();
}
    
}

void UpdateScore()
{

score += Time.deltaTime * scoreMultiplier;

scoreText.text = Mathf.FloorToInt(score).ToString();

}

public void ContinueGame()
{

  StartScore();
  player.transform.position = Vector3.zero;
  player.SetActive(true);
  astroidSpawner.enabled = true;
  gameOverDisplay.gameObject.SetActive(false);
  scoreDisplay.gameObject.SetActive(true);

}


}
