using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RetryUI : MonoBehaviour
{
    public Button RetryButton;
    public Button HomeButton;
    void Start()
    {
        Time.timeScale = 0;
        RetryButton.onClick.AddListener(Retry);
        HomeButton.onClick.AddListener(Home);
    }

    void Retry()
    {
        SceneManager.LoadScene("Demo6");
        Time.timeScale = 1;
    }

    void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
