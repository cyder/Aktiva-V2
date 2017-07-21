using System.Collections.Generic;
using UnityEngine;
using SongUtility;

public class SongManager : MonoBehaviour
{
  static Song nowPlaySong; // 現在再生中の曲
  static List<Song> songList = new List<Song>(); // 再生待ちの曲

  void Update()
  {
    // ここでsongListへの格納等を行う。
  }

  public static Song getNowPlaySong()
  {
    return nowPlaySong;
  }

  public static Song getStandbySong(int index)
  {
    return songList[index];
  }

  public static int numStandBySong()
  {
    return songList.Count;
  }
}
