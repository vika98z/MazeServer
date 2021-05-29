using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
  public void GetPlayer()
  {
    PlayerPrefs.SetString("mode", "player");
    StartGame();
  }

  public void GetOperator()
  {
    PlayerPrefs.SetString("mode", "operator");
    StartGame();
  }

  public void Menu()
  {
    SceneManager.LoadScene(0);
  }

  private void StartGame()
  {
    SceneManager.LoadScene(1);
  }
}