﻿using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UserInputs;
using SongUtility;

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
    StartCoroutine(VideoSetup());

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

  IEnumerator VideoSetup ()
  {
    SongManager songManager = GameObject.Find("SongManager").GetComponent<SongManager>();
    Song song = songManager.getNowPlaySong();

    while (!song.IsLoad)
    {
      yield return null;
    }

    videoPlayer = GetComponent<VideoPlayer>();
    videoPlayer.url = song.Url;
    videoPlayer.Prepare();
    videoPlayer.loopPointReached += MovieEndEvent;
  }
}
