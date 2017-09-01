using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class ChangePlaySpeed : UserInput
  {
    decimal data = 1.0m;

    public ChangePlaySpeed() : base("ChangePlaySpeed") { }

    protected override void ResetData()
    {
    }

    protected override void UpdateData()
    {
      decimal lastData = Data;

      if (Input.GetKeyDown(KeyCode.Minus) && data > 0.5m)
      {
        Data -= 0.1m;
      }

      if (Input.GetKeyDown(KeyCode.Equals) && data < 1.0m)
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
