#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public Text BestScoreText;
    public InputField InputField;

    private void Awake()
    {
        PlayerData.Instance.LoadScore();
    }

    private void Start()
    {
        BestScoreText.text = $"Best Score: {PlayerData.Instance.PlayerName}: {PlayerData.Instance.BestScore}";
    }

    public void StartNew()
    {
        PlayerData.Instance.PlayerName = InputField.text;
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
