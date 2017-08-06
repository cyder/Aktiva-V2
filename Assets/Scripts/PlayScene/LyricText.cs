﻿using UnityEngine;
using UnityEngine.UI;
using SongUtility;

public class LyricText : MonoBehaviour
{

  Text text;
  Song song;
  int nextLyricIndex = 0;

  void Start ()
  {
    text = gameObject.GetComponent<Text>();
    song = SongManager.getNowPlaySong();
  }

  void Update ()
  {
    Lyric nextLyric = song.GetLyric(nextLyricIndex);

    if (DanceVideoPlayer.time > nextLyric.time)
    {
      text.text = nextLyric.text;
      nextLyricIndex++;
    }
  }
}
