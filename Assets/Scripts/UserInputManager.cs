﻿﻿using System;
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
    foreach (var input in userInput)
    {
      input.Update();
    }
  }

  public static UserInput GetUserInput(UserInputCode code)
  {
    return userInput[(int)code];
  }
}
