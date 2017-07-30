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

  void Start ()
  {
    addSong = (AddSong)UserInputManager.GetUserInput(UserInputCode.AddSong);
    addSong.OnValueChanged += OnAddSongValueChanged;
  }

  // 曲追加時のポップアップ
  void OnAddSongValueChanged(object sender, UserInputEventArgs e)
  {
    DestroyObject(popup);

    Debug.Log(addSongPopup.gameObject.transform.position);

    popup = Instantiate(addSongPopup);
    popup.transform.SetParent(transform, false);

    Song song = addSong.GetData(0);

    var songTitle = popup.transform.Find("SongTitle").gameObject.GetComponent<Text>();
    songTitle.text = song.title;
    var artistName = popup.transform.Find("ArtistName").gameObject.GetComponent<Text>();
    artistName.text = song.artist;

    StartCoroutine(DestroyObjectDelay(3.0f, popup));
  }

  // 出ているポップアップの削除
  void DestroyObject(GameObject target)
  {
    if (target != null)
    {
      Destroy(target);
    }
  }

  // メソッドを指定時間遅らせて実行
  IEnumerator DestroyObjectDelay(float waitTime, GameObject target)
  {
    yield return new WaitForSeconds(waitTime);
    DestroyObject(target);
  }
}
