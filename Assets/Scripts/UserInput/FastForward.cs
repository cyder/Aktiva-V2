﻿using System.Collections.Generic;
using UnityEngine;

namespace UserInputs
{
  public class FastForward : UserInput
  {
    public FastForward() : base("FastForward") { }

    protected override void ResetData()
    {
    }

    protected override void UpdateData()
    {
      if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        OnDataUpdated();
      }
    }
  }
}
