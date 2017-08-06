using System;

namespace SongUtility
{
  public class Lyric
  {
    string _text; // 歌詞
    double _time; // 動画開始時刻からの時間

    // timeは"%M:%S:%L"のテキストで指定する
    public Lyric(string text, string stringTime)
    {
      this.text = text;
      string[] stringTimeElements = stringTime.Split(':');

      if (stringTimeElements.Length != 3)
      {
        return;
      }

      double[] timeElements = new double[stringTimeElements.Length];

      try
      {
        for (int i = 0; i < stringTimeElements.Length; i++)
        {
          timeElements[i] = Double.Parse(stringTimeElements[i]);
        }
      }
      catch (FormatException e)
      {
        return;
      }

      this.time = timeElements[0] * 60.0 + timeElements[1] + timeElements[2] * 0.001;
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

    public double time
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
