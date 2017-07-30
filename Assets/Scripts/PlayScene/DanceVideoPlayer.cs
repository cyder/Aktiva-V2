using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class DanceVideoPlayer : MonoBehaviour
{
  static VideoPlayer videoPlayer;
  static GameObject videoScreen;
  static bool _isEnded = false;

  void Start ()
  {
    videoScreen = GameObject.Find("VideoScreen");
    videoScreen.SetActive(false);
    videoPlayer = GetComponent<VideoPlayer>();
    videoPlayer.url = "https://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
    videoPlayer.Prepare();
    videoPlayer.loopPointReached += MovieEndEvent;
  }

  void MovieEndEvent(VideoPlayer vp)
  {
    isEnded = true;
  }

  public static void StartPlay()
  {
    videoScreen.SetActive(true);
    videoPlayer.Play();
    isEnded = false;
  }

  public static bool isPrepared
  {
    get
    {
      return videoPlayer.isPrepared;
    }
  }

  public static bool isEnded
  {
    get
    {
      return _isEnded;
    }

    private set
    {
      _isEnded = value;
    }
  }
}
