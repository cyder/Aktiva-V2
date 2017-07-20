using System;

namespace UserInputs
{
  public class UserInputEventArgs : EventArgs
  {
    string _userInputName;
    public string userInputName
    {
      get
      {
        return _userInputName;
      }
    }

    public UserInputEventArgs(string userInputName)
    {
      _userInputName = userInputName;
    }
  }
}
