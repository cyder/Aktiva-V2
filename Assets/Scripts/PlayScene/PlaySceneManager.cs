using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{
  DanceVideoPlayer danceVideoPlayer;

  public void Play()
  {
    SceneManager.LoadScene("SongInfomation", LoadSceneMode.Additive);
    danceVideoPlayer = GameObject.Find("DanceVideoPlayer").GetComponent<DanceVideoPlayer>();
    danceVideoPlayer.StartPlay(); // 動画の再生開始
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
