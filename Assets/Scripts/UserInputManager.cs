﻿using System;
using UnityEngine;
using UserInputs;

public enum UserInputCode
{
  AddSong,
  FastForward,
  Pause,
  Playback,
  Restart,
  Rewind,
  Stop
}

public class UserInputManager : MonoBehaviour
{
  static UserInput[] userInput = new UserInput[Enum.GetNames(typeof(UserInputCode)).Length];

  void Start()
  {
    userInput[(int)UserInputCode.AddSong] = new AddSong();
    userInput[(int)UserInputCode.FastForward] = new FastForward();
    userInput[(int)UserInputCode.Pause] = new Pause();
    userInput[(int)UserInputCode.Playback] = new Playback();
    userInput[(int)UserInputCode.Restart] = new Restart();
    userInput[(int)UserInputCode.Rewind] = new Rewind();
    userInput[(int)UserInputCode.Stop] = new Stop();
  }

  void Update()
  {
    foreach (UserInputCode code in Enum.GetValues(typeof(UserInputCode)))
    {
      userInput[(int)code].Update();
    }
  }

  public static bool GetUpdateFlag(UserInputCode code)
  {
    return userInput[(int)code].GetUpdateFlag();
  }

  public static UserInput GetUserInput(UserInputCode code)
  {
    return userInput[(int)code];
  }
}
