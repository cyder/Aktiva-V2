using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{
  void Start ()
  {
    SceneManager.LoadScene("DanceMovie", LoadSceneMode.Additive);
    SceneManager.LoadScene("SongInfomation", LoadSceneMode.Additive);
  }

  void OnDestroy ()
  {
    SceneManager.UnloadScene("DanceMovie");
    SceneManager.UnloadScene("SongInfomation");
  }
}
