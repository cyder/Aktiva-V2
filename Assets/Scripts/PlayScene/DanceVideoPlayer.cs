﻿using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UserInputs;

public class DanceVideoPlayer : MonoBehaviour
{
  VideoPlayer videoPlayer;
  GameObject videoScreen;
  bool isEnded = false;
  UserInput pause, playback, fastForward, rewind, restart, stop;
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
    fastForward = UserInputManager.GetUserInput(UserInputCode.FastForward);
    fastForward.OnValueChanged += OnFastForwardValueChanged;
    rewind = UserInputManager.GetUserInput(UserInputCode.Rewind);
    rewind.OnValueChanged += OnRewindValueChanged;
    restart = UserInputManager.GetUserInput(UserInputCode.Restart);
    restart.OnValueChanged += OnRestartValueChanged;
    stop = UserInputManager.GetUserInput(UserInputCode.Stop);
    stop.OnValueChanged += OnStopValueChanged;
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

  void OnFastForwardValueChanged(object sender, UserInputEventArgs e)
  {
    videoPlayer.time += 10.0;
  }

  void OnRewindValueChanged(object sender, UserInputEventArgs e)
  {
    videoPlayer.time -= 10.0;
  }

  void OnRestartValueChanged(object sender, UserInputEventArgs e)
  {
    videoPlayer.time = 0;
  }

  void OnStopValueChanged(object sender, UserInputEventArgs e)
  {
    IsEnded = true;
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
