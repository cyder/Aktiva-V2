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
  ChangePlaySpeed changePlaySpeed;
  ChangeVolume changeVolume;

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
    changePlaySpeed = (ChangePlaySpeed)UserInputManager.GetUserInput(UserInputCode.ChangePlaySpeed);
    changePlaySpeed.OnValueChanged += OnPlaySpeedValueChanged;
    changeVolume = (ChangeVolume)UserInputManager.GetUserInput(UserInputCode.ChangeVolume);
    changeVolume.OnValueChanged += OnVolumeValueChanged;
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

  void OnPlaySpeedValueChanged(object sender, UserInputEventArgs e)
  {
    videoPlayer.playbackSpeed = (float)changePlaySpeed.Data;
  }

  void OnVolumeValueChanged(object sender, UserInputEventArgs e)
  {
    videoPlayer.SetDirectAudioVolume(0, (float)changeVolume.Data);
  }

  void MovieEndEvent(VideoPlayer vp)
  {
    isEnded = true;
  }
}
