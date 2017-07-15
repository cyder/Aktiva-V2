using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class Rewind : UserInput
  {
    protected override void ResetData()
    {
    }

    protected override void UpdateData()
    {
      if (Input.GetKeyDown(KeyCode.LeftAlt))
      {
        DataUpdated();
      }
    }
  }
}
