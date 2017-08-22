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
    StartCoroutine(LoadStandbyScene());
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
          StartCoroutine(LoadStandbyScene());
          break;

        case SceneType.SongListScene:
          StartCoroutine(LoadSongListScene());
          StartCoroutine(LoadPlayScene());
          break;
      }

      lastScene = currentScene;
    }
  }

  // StandbySceneをロード
  IEnumerator LoadStandbyScene()
  {
    yield return SceneManager.LoadSceneAsync("StandbyScene", LoadSceneMode.Additive);
  }

  // SongListSceneをロード
  IEnumerator LoadSongListScene()
  {
    yield return SceneManager.LoadSceneAsync("SongListScene", LoadSceneMode.Additive);
  }

  // PlaySceneをロード
  IEnumerator LoadPlayScene()
  {
    yield return SceneManager.LoadSceneAsync("PlayScene", LoadSceneMode.Additive);
    StartCoroutine(ChangePlaySceneDelay(SongListSceneTime));
  }

  // 指定時間遅らせてPlaySceneを開始
  IEnumerator ChangePlaySceneDelay(float waitTime)
  {
    yield return new WaitForSeconds(waitTime);

    danceVideoPlayer = GameObject.Find("DanceVideoPlayer").GetComponent<DanceVideoPlayer>();

    while (!danceVideoPlayer.isPrepared)
    {
      yield return null;
    }

    currentScene = SceneType.PlayScene;
    danceVideoPlayer.StartPlay(); // 動画の再生開始
  }
}
