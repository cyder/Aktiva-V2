using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class ChangeVolume : UserInput
  {
    decimal data = 1.0m;

    public ChangeVolume() : base("ChangeVolume") { }

    protected override void ResetData()
    {
    }

    protected override void UpdateData()
    {
      decimal lastData = Data;

      if (Input.GetKeyDown(KeyCode.DownArrow) && data > 0.0m)
      {
        Data -= 0.1m;
      }

      if (Input.GetKeyDown(KeyCode.UpArrow) && data < 1.0m)
      {
        Data += 0.1m;
      }

      if (Data != lastData)
      {
        OnDataUpdated();
      }
    }

    public decimal Data
    {
      get
      {
        return data;
      }

      private set
      {
        data = value;
      }
    }
  }
}
