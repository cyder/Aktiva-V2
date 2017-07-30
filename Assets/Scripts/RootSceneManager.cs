using UnityEngine;
using UnityEngine.SceneManagement;

public class RootSceneManager : MonoBehaviour
{
  enum SceneName { StandbyScene, SongListScene, PlayScene };
  const SceneName startScene = SceneName.StandbyScene; // 初期Scene
  SceneName currentScene, lastScene; // 現在のScene, 1フレーム前のScene

  void Start()
  {
    SceneManager.LoadScene(startScene.ToString(), LoadSceneMode.Additive);
    currentScene = lastScene = startScene;
  }

  void Update()
  {
    if (currentScene == SceneName.StandbyScene && SongManager.numStandBySong() > 0)
    {
      currentScene = SceneName.SongListScene;
    }
  }

  void LateUpdate()
  {
    if (currentScene != lastScene)
    {
      SceneManager.UnloadScene(lastScene.ToString());

      switch (currentScene)
      {
        case SceneName.StandbyScene:
          SceneManager.LoadScene("StandbyScene", LoadSceneMode.Additive);
          break;

        case SceneName.SongListScene:
          SceneManager.LoadScene("SongListScene", LoadSceneMode.Additive);
          SceneManager.LoadScene("PlayScene", LoadSceneMode.Additive);
          break;
      }

      lastScene = currentScene;
    }
  }
}
