using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject mainButtonsGO;
    [SerializeField] private GameObject optionsPanelGO;

    private void Awake()
    {
        soundManager.StartMenuMusic();
        ActivatePanel(mainButtonsGO, true);
        ActivatePanel(optionsPanelGO, false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenOptionsPanel()
    {
        ActivatePanel(mainButtonsGO, false);
        ActivatePanel(optionsPanelGO, true);
    }
    public void CloseOptionsPanel()
    {
        ActivatePanel(mainButtonsGO, true);
        ActivatePanel(optionsPanelGO, false);
    }
    public void ActivatePanel(GameObject go, bool value)
    {
        go.SetActive(value);
    }
}
