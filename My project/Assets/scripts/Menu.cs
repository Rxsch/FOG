using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame() { SceneManager.LoadScene("GameScene"); }
    public void QuitGame() { Application.Quit(); }
}