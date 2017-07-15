namespace UserInputs
{
  public abstract class UserInput
  {
    bool updateFlag = false; // 受信フラグ

    public bool GetUpdateFlag()
    {
      return updateFlag;
    }

    public void DataUpdated()
    {
      updateFlag = true;
    }

    public void Reset()
    {
      updateFlag = false;
      ResetData();
    }

    public void Update()
    {
      Reset();
      UpdateData();
    }

    protected abstract void ResetData(); // 中身のデータのリセット
    protected abstract void UpdateData(); // データのアップデート
  }
}
