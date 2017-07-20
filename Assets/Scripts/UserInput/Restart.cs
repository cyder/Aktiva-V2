using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class Restart : UserInput
  {
    public Restart() : base("Restart") { }

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
