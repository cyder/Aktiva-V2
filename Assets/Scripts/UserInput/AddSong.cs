﻿using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class AddSong : UserInput
  {
    List<int> data = new List<int>();

    protected override void ResetData()
    {
      data.Clear();
    }

    protected override void UpdateData()
    {
      // 曲ID1の追加
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        data.Add(1);
      }

      // 曲ID2の追加
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        data.Add(2);
      }

      // 曲ID3の追加
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
        data.Add(3);
      }

      if (data.Count != 0)
      {
        DataUpdated();
      }
    }

    public int GetData(int index)
    {
      return data[index];
    }
  }
}
