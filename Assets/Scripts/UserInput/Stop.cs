using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class Stop : UserInput
  {
    public Stop() : base("Stop") { }

    protected override void ResetData()
    {
    }

    protected override void UpdateData()
    {
      if (Input.GetKeyDown(KeyCode.S))
      {
        OnDataUpdated();
      }
    }
  }
}
