using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class FastForward : UserInput
  {
    protected override void ResetData()
    {
    }

    protected override void UpdateData()
    {
      if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        DataUpdated();
      }
    }
  }
}
