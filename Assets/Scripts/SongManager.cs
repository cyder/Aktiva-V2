using System.Collections.Generic;
using UnityEngine;
using SongUtility;
using UserInputs;

public class SongManager : MonoBehaviour
{
  Song nowPlaySong; // 現在再生中の曲
  List<Song> songList = new List<Song>(); // 再生待ちの曲
  AddSong addSong;

  void Start()
  {
    addSong = (AddSong)UserInputManager.GetUserInput(UserInputCode.AddSong);
    addSong.OnValueChanged += OnValueChanged;
  }

  void OnValueChanged(object sender, UserInputEventArgs e)
  {
    for (int i = 0; i < addSong.GetDataLangth(); i++)
    {
      songList.Add(addSong.GetData(i));
    }
  }

  public Song getNowPlaySong()
  {
    return nowPlaySong;
  }

  public Song getStandbySong(int index)
  {
    return songList[index];
  }

  public int numStandBySong()
  {
    return songList.Count;
  }

  public void setNextSong()
  {
    nowPlaySong = songList[0];
    songList.RemoveAt(0);
  }
}
