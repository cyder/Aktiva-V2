﻿﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RootSceneManager : MonoBehaviour
{
  enum SceneType { StandbyScene, SongListScene, PlayScene };
  const SceneType startScene = SceneType.StandbyScene; // 初期Scene
  SceneType currentScene, lastScene; // 現在のScene, 1フレーム前のScene
  const float SongListSceneTime = 5.0f;

  void Start()
  {
    SceneManager.LoadScene(startScene.ToString(), LoadSceneMode.Additive);
    currentScene = lastScene = startScene;
  }

  void Update()
  {
    if (currentScene == SceneType.PlayScene && DanceVideoPlayer.isEnded)
    {
      currentScene = SceneType.StandbyScene;
    }

    if (currentScene == SceneType.StandbyScene && SongManager.numStandBySong() > 0)
    {
      currentScene = SceneType.SongListScene;
      SongManager.setNextSong();
    }
  }

  void LateUpdate()
  {
    if (currentScene != lastScene)
    {
      SceneManager.UnloadScene(lastScene.ToString());

      switch (currentScene)
      {
        case SceneType.StandbyScene:
          SceneManager.LoadScene("StandbyScene", LoadSceneMode.Additive);
          break;

        case SceneType.SongListScene:
          SceneManager.LoadScene("SongListScene", LoadSceneMode.Additive);
          SceneManager.LoadScene("PlayScene", LoadSceneMode.Additive);
          StartCoroutine(ChangePlaySceneDelay(SongListSceneTime));
          break;
      }

      lastScene = currentScene;
    }
  }

  // 指定時間遅らせてPlaySceneを開始
  IEnumerator ChangePlaySceneDelay(float waitTime)
  {
    yield return new WaitForSeconds(waitTime);

    while (!DanceVideoPlayer.isPrepared)
    {
      yield return null;
    }

    currentScene = SceneType.PlayScene;
    DanceVideoPlayer.StartPlay(); // 動画の再生開始
  }
}
