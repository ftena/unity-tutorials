using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // required to use TextMeshPro
using UnityEngine.SceneManagement; // to interact with scenes in the scene folder
using UnityEngine.UI; // required to interact with the buttons

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject titleScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive = true;
    public float spawnRate = 1.0f;
    private int score = 0;    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {        
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
