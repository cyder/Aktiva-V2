using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class Restart : UserInput
  {
    protected override void ResetData()
    {
    }

    protected override void UpdateData()
    {
      if (Input.GetKeyDown(KeyCode.R))
      {
        DataUpdated();
      }
    }
  }
}
