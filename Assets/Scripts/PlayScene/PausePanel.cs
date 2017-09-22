using UnityEngine;
using UserInputs;

public class PausePanel : MonoBehaviour
{
  UserInput pause, playback;

  void Start ()
  {
    pause = UserInputManager.GetUserInput(UserInputCode.Pause);
    pause.OnValueChanged += OnPauseValueChanged;
    playback = UserInputManager.GetUserInput(UserInputCode.Playback);
    playback.OnValueChanged += OnPlaybackValueChanged;
    gameObject.SetActive(false);
  }

  void OnPauseValueChanged(object sender, UserInputEventArgs e)
  {
    if (!gameObject.activeInHierarchy)
    {
      gameObject.SetActive(true);
    }
  }

  void OnPlaybackValueChanged(object sender, UserInputEventArgs e)
  {
    if (gameObject.activeInHierarchy)
    {
      gameObject.SetActive(false);
    }
  }

  void OnDestroy()
  {
    pause.OnValueChanged -= OnPauseValueChanged;
    playback.OnValueChanged -= OnPlaybackValueChanged;
  }
}
