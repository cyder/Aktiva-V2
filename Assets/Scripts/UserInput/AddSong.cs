﻿﻿﻿using System.Collections.Generic;
using UnityEngine;
using SongUtility;

namespace UserInputs
{
  public class AddSong : UserInput
  {
    List<Song> data = new List<Song>();

    public AddSong() : base("AddSong") { }

    protected override void ResetData()
    {
      data.Clear();
    }

    protected override void UpdateData()
    {
      // 曲ID1の追加
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        data.Add(new Song(1));
      }

      // 曲ID2の追加
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        data.Add(new Song(2));
      }

      // 曲ID3の追加
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
        data.Add(new Song(3));
      }

      if (data.Count != 0)
      {
        OnDataUpdated();
      }
    }

    public Song GetData(int index)
    {
      return data[index];
    }
  }
}
