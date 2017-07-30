using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class DanceVideoPlayer : MonoBehaviour
{
  static VideoPlayer videoPlayer;
  static GameObject videoScreen;

  void Start ()
  {
    videoScreen = GameObject.Find("VideoScreen");
    videoScreen.SetActive(false);
    videoPlayer = GetComponent<VideoPlayer>();
    videoPlayer.url = "https://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
    videoPlayer.Prepare();
  }

  static void StartPlay()
  {
    videoScreen.SetActive(true);
    videoPlayer.Play();
  }

  static bool isPrepared
  {
    get
    {
      return videoPlayer.isPrepared;
    }
  }
}
