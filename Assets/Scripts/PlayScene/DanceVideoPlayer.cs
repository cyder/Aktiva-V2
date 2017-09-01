﻿using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UserInputs;

public class DanceVideoPlayer : MonoBehaviour
{
  VideoPlayer videoPlayer;
  GameObject videoScreen;
  bool isEnded = false;
  UserInput pause, playback;

  public void StartPlay()
  {
    videoScreen.SetActive(true);
    videoPlayer.Play();
    IsEnded = false;
  }

  public bool isPrepared
  {
    get
    {
      return videoPlayer.isPrepared;
    }
  }


  public double Time
  {
    get
    {
      return videoPlayer.time;
    }
  }

  public bool IsEnded
  {
    get
    {
      return isEnded;
    }

    private set
    {
      isEnded = value;
    }
  }

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
}
