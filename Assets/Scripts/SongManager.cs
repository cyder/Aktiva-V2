using System.Collections.Generic;
using UnityEngine;
using SongUtility;
using UserInputs;

public class SongManager : MonoBehaviour
{
  static Song nowPlaySong; // 現在再生中の曲
  static List<Song> songList = new List<Song>(); // 再生待ちの曲
  AddSong addSong;

  void Start()
  {
    addSong = (AddSong)UserInputManager.GetUserInput(UserInputCode.AddSong);
    addSong.OnValueChanged += OnValueChanged;
  }

  void OnValueChanged(object sender, UserInputEventArgs e)
  {
    Debug.Log(addSong.GetData(0));
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
