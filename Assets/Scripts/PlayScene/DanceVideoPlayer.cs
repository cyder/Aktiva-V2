using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class DanceVideoPlayer : MonoBehaviour
{
  VideoPlayer videoPlayer;

  void Start ()
  {
    videoPlayer = GetComponent<VideoPlayer>();
    videoPlayer.url = "https://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
    videoPlayer.Prepare();
    StartCoroutine(StartPlay());
  }

  IEnumerator StartPlay()
  {
    while (!videoPlayer.isPrepared)
    {
      yield return 0;
    }

    videoPlayer.Play();
  }
}
