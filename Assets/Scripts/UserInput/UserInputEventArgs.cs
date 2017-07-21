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

      private set
      {
        _userInputName = value;
      }
    }

    public UserInputEventArgs(string userInputName)
    {
      this.userInputName = userInputName;
    }
  }
}
