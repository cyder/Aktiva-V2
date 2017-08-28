﻿using UnityEngine;
using UnityEngine.UI;
using SongUtility;

public class LyricText : MonoBehaviour
{

  Text text;
  Song song;
  int nextLyricIndex = 0;
  SongManager songManage;
  DanceVideoPlayer danceVideoPlayer;

  void Start ()
  {
    text = gameObject.GetComponent<Text>();
    songManage = GameObject.Find("SongManager").GetComponent<SongManager>();
    song = songManage.getNowPlaySong();
    danceVideoPlayer = GameObject.Find("DanceVideoPlayer").GetComponent<DanceVideoPlayer>();
  }

  void Update ()
  {
    Lyric nextLyric = song.GetLyric(nextLyricIndex);

    if (danceVideoPlayer.Time > nextLyric.time)
    {
      text.text = nextLyric.text;
      nextLyricIndex++;
    }
  }
}
