using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public InputField PlayerNameText;

    public void Start ()
    {
        PlayerNameText.text = GameManager.Instance.PlayerName;
    }

    public void StartGame ()
    {
        GameManager.Instance.PlayerName = PlayerNameText.text;
        SceneManager.LoadScene(1);
    }

    public void ExitApplication ()
    {
        GameManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
