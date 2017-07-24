using System;
using System.Collections;
﻿﻿using UnityEngine;
using UnityEngine.UI;
using SongUtility;
using UserInputs;

public class Popup : MonoBehaviour
{
  public GameObject addSongPopup;
  GameObject popup;
  AddSong addSong;
  Coroutine coroutine;

  void Start ()
  {
    addSong = (AddSong)UserInputManager.GetUserInput(UserInputCode.AddSong);
    addSong.OnValueChanged += OnAddSongValueChanged;
  }

  // 曲追加時のポップアップ
  void OnAddSongValueChanged(object sender, UserInputEventArgs e)
  {
    Clear();

    if (coroutine != null)
    {
      StopCoroutine(coroutine);
    }

    popup = Instantiate(
              addSongPopup,
              transform.position,
              Quaternion.identity
            );
    popup.transform.SetParent(transform);

    Song song = addSong.GetData(0);

    Text songTitle = popup.transform.Find("SongTitle").gameObject.GetComponent<Text>();
    songTitle.text = song.title;
    Text artistName = popup.transform.Find("ArtistName").gameObject.GetComponent<Text>();
    artistName.text = song.artist;
    coroutine = StartCoroutine(DelayMethod(3.0f, () =>
    {
      Clear();
    }));
  }

  // 出ているポップアップの削除
  void Clear()
  {
    if (popup != null)
    {
      Destroy(popup);
    }
  }

  // メソッドを指定時間遅らせて実行
  IEnumerator DelayMethod(float waitTime, Action action)
  {
    yield return new WaitForSeconds(waitTime);
    action();
  }
}
