using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UserInputs;

public class DanceVideoPlayer : MonoBehaviour
{
  static VideoPlayer videoPlayer;
  static GameObject videoScreen;
  static bool _isEnded = false;
  UserInput pause, playback;

  void Start ()
  {
    videoScreen = GameObject.Find("VideoScreen");
    videoScreen.SetActive(false);
    videoPlayer = GetComponent<VideoPlayer>();
    videoPlayer.url = "https://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
    videoPlayer.Prepare();
    videoPlayer.loopPointReached += MovieEndEvent;

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
