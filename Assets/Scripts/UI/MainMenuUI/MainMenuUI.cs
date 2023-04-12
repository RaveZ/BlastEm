using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button PlayButton;
    public Button TutorialButton;
    public Button BackButton;
    public GameObject TutorialUI;
    void Start()
    {
        TutorialButton.onClick.AddListener(Tutorial);
        PlayButton.onClick.AddListener(Play);
        BackButton.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Back()
    {
        TutorialUI.SetActive(false);
    }

    void Tutorial()
    {
        TutorialUI.SetActive(true);
    }

    void Play()
    {
        SceneManager.LoadScene("Demo6");
    }
}
