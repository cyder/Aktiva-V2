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
  Stop,
  ChangePlaySpeed,
  ChangeVolume
}

public class UserInputManager : MonoBehaviour
{
  static UserInput[] userInput =
  {
    new AddSong(),
    new FastForward(),
    new Pause(),
    new Playback(),
    new Restart(),
    new Rewind(),
    new Stop(),
    new ChangePlaySpeed(),
    new ChangeVolume(),
  };

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
