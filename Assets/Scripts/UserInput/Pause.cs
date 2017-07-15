using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class Pause : UserInput
  {
    protected override void ResetData()
    {
    }

    protected override void UpdateData()
    {
      if (Input.GetKeyDown(KeyCode.P))
      {
        DataUpdated();
      }
    }
  }
}
