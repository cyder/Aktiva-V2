using System;

namespace SongUtility
{
  enum ScoreName
  {
    Smile,
    Jump,
    Extensiveness,
    Intensity,
    Rhythm
  }

  public class DanceScore
  {
    int[] score = new int[Enum.GetNames(typeof(ScoreName)).Length];
  }
}
