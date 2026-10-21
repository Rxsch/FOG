using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;

    [Header("Main Menu Scene")]
    [SerializeField] private string mainMenuSceneName = "mainMenu";

    public static bool IsPaused { get; private set; }

    private void Start()
    {
        // Disable this component if its required references are missing.
        if (pausePanel == null || optionsPanel == null)
        {
            Debug.LogError(
                "Assign Pause Panel and Options Panel on this object.",
                this
            );

            enabled = false;
            return;
        }

        Resume();
    }

 private void Update()
{
    if (!Input.GetKeyDown(KeyCode.Escape))
        return;

    if (!IsPaused)
        Pause();
    else if (optionsPanel.activeSelf)
        CloseOptions();
    else
        Resume();

    Debug.Log(
        $"Frame: {Time.frameCount} | Component: {GetEntityId()} | " +
        $"Paused: {IsPaused} | Time scale: {Time.timeScale} | " +
        $"Panel: {pausePanel.name} | " +
        $"Panel active: {pausePanel.activeSelf} | " +
        $"Panel visible in hierarchy: {pausePanel.activeInHierarchy}",
        this
    );
}
    public void Pause()
    {
        pausePanel.SetActive(true);
        optionsPanel.SetActive(false);

        Time.timeScale = 0f;
        IsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);

        Time.timeScale = 1f;
        IsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenOptions()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        IsPaused = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = Mathf.Clamp01(value);
    }
}