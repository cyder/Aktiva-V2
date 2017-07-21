﻿namespace UserInputs
{
  public abstract class UserInput
  {
    public delegate void UserInputEventHandler(UserInput userInput, UserInputEventArgs e);
    public event UserInputEventHandler OnValueChanged;
    string userInputName;

    bool _updateFlag = false; // 受信フラグ
    public bool updateFlag
    {
      get
      {
        return _updateFlag;
      }
      set
      {
        if (!_updateFlag && value && OnValueChanged != null)
        {
          OnValueChanged(this, new UserInputEventArgs(userInputName));
        }

        _updateFlag = value;
      }
    }

    public UserInput(string userInputName)
    {
      this.userInputName = userInputName;
    }

    public void OnDataUpdated()
    {
      updateFlag = true;
    }

    public void Update()
    {
      updateFlag = false;
      ResetData();
      UpdateData();
    }

    protected abstract void ResetData(); // 中身のデータのリセット
    protected abstract void UpdateData(); // データのアップデート
  }
}
