using System;

namespace SongUtility
{
  public class Lyric
  {
    string _text; // 歌詞
    DateTime _time; // 動画開始時刻からの時間

    // timeは"%M:%S:%L"のテキストで指定する
    public Lyric(string text, string stringTime)
    {
      this.text = text;
      string[] stringTimeElements = stringTime.Split(':');

      if (stringTimeElements.Length != 3)
      {
        return;
      }

      int[] timeElements = new int[stringTimeElements.Length];

      try
      {
        for (int i = 0; i < stringTimeElements.Length; i++)
        {
          timeElements[i] = Int32.Parse(stringTimeElements[i]);
        }
      }
      catch (FormatException e)
      {
        return;
      }

      this.time = new DateTime(2000, 1, 1, 0,
                               timeElements[0],  // 分
                               timeElements[1],  // 秒
                               timeElements[2]); // ミリ秒
    }

    public string text
    {
      get
      {
        return _text;
      }

      private set
      {
        _text = value;
      }
    }

    public DateTime time
    {
      get
      {
        return _time;
      }

      private set
      {
        _time = value;
      }
    }

  }
}
