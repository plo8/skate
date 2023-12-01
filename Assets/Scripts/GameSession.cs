using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Scripting;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    int playerScore = 0;
    public float restartDelay = 0.001f;

    // Start is called before the first frame update
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = playerScore.ToString();
    }

    public void afterFail()
    {
        StartCoroutine(RestartWithDelay(restartDelay));
    }

    public void addToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        scoreText.text = playerScore.ToString();
    }

    public IEnumerator RestartWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
