using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SongUtility;

public class SongInfomation : MonoBehaviour
{
  void Start ()
  {
    Song song = SongManager.getNowPlaySong();
    var songTitle = this.transform.Find("SongTitle").gameObject.GetComponent<Text>();
    songTitle.text = song.title;
    var artistName = this.transform.Find("ArtistName").gameObject.GetComponent<Text>();
    artistName.text = song.artist;
    StartCoroutine(DestroyObjectDelay(3.0f, this.gameObject));
  }

  // 一定時間後に削除
  IEnumerator DestroyObjectDelay(float waitTime, GameObject target)
  {
    yield return new WaitForSeconds(waitTime);
    Destroy(target);
  }
}
