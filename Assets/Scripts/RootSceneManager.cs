﻿﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RootSceneManager : MonoBehaviour
{
  enum SceneType { StandbyScene, SongListScene, PlayScene };
  const SceneType startScene = SceneType.StandbyScene; // 初期Scene
  SceneType currentScene, lastScene; // 現在のScene, 1フレーム前のScene
  const float SongListSceneTime = 5.0f;
  SongManager songManage;
  DanceVideoPlayer danceVideoPlayer;

  void Start()
  {
    SceneManager.LoadSceneAsync(startScene.ToString(), LoadSceneMode.Additive);
    currentScene = lastScene = startScene;
    songManage = GameObject.Find("SongManager").GetComponent<SongManager>();
  }

  void Update()
  {
    if (currentScene == SceneType.PlayScene && danceVideoPlayer.IsEnded)
    {
      currentScene = SceneType.StandbyScene;
    }

    if (currentScene == SceneType.StandbyScene && songManage.numStandBySong() > 0)
    {
      currentScene = SceneType.SongListScene;
      songManage.setNextSong();
    }
  }

  void LateUpdate()
  {
    if (currentScene != lastScene)
    {
      SceneManager.UnloadSceneAsync(lastScene.ToString());

      switch (currentScene)
      {
        case SceneType.StandbyScene:
          SceneManager.LoadSceneAsync("StandbyScene", LoadSceneMode.Additive);
          break;

        case SceneType.SongListScene:
          SceneManager.LoadSceneAsync("SongListScene", LoadSceneMode.Additive);
          StartCoroutine(LoadPlayScene());
          break;
      }

      lastScene = currentScene;
    }
  }

  // PlaySceneをロード
  IEnumerator LoadPlayScene()
  {
    yield return SceneManager.LoadSceneAsync("PlayScene", LoadSceneMode.Additive);

    // 指定時間遅らせてPlaySceneを開始
    yield return new WaitForSeconds(SongListSceneTime);

    danceVideoPlayer = GameObject.Find("DanceVideoPlayer").GetComponent<DanceVideoPlayer>();

    while (!danceVideoPlayer.isPrepared)
    {
      yield return null;
    }

    currentScene = SceneType.PlayScene;

    PlaySceneManager playSceneManager = GameObject.Find("PlaySceneManager").GetComponent<PlaySceneManager>();
    playSceneManager.Play(); // 動画の再生開始
  }
}
