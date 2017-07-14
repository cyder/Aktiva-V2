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
    // ここでcurrentSceneを変更する
  }

  void LateUpdate()
  {
    if (currentScene != lastScene)
    {
      SceneManager.UnloadScene(lastScene.ToString());
      SceneManager.LoadScene(currentScene.ToString(), LoadSceneMode.Additive);
      lastScene = currentScene;
    }
  }
}
