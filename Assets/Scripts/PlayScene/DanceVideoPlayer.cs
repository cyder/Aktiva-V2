using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UserInputs;

public class DanceVideoPlayer : MonoBehaviour
{
  VideoPlayer videoPlayer;
  UserInput pause, playback;

  void Start ()
  {
    videoPlayer = GetComponent<VideoPlayer>();
    videoPlayer.url = "https://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
    videoPlayer.Prepare();
    StartCoroutine(StartPlay());

    pause = UserInputManager.GetUserInput(UserInputCode.Pause);
    pause.OnValueChanged += OnPauseValueChanged;
    playback = UserInputManager.GetUserInput(UserInputCode.Playback);
    playback.OnValueChanged += OnPlaybackValueChanged;
  }

  void OnPauseValueChanged(object sender, UserInputEventArgs e)
  {
    if (videoPlayer.isPlaying)
    {
      videoPlayer.Pause();
    }
  }

  void OnPlaybackValueChanged(object sender, UserInputEventArgs e)
  {
    if (!videoPlayer.isPlaying)
    {
      videoPlayer.Play();
    }
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
