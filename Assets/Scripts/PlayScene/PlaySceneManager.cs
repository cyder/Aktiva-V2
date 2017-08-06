using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{
  static public void Play()
  {
    SceneManager.LoadScene("SongInfomation", LoadSceneMode.Additive);
    DanceVideoPlayer.StartPlay(); // 動画の再生開始
  }

  void Start ()
  {
    SceneManager.LoadScene("DanceMovie", LoadSceneMode.Additive);
  }

  void OnDestroy ()
  {
    SceneManager.UnloadScene("DanceMovie");
    SceneManager.UnloadScene("SongInfomation");
  }
}
