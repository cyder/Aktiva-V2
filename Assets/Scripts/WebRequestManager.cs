using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WebRequestManager : MonoBehaviour
{
  public void GetSongData (int songId)
  {
    StartCoroutine(GetSongCoroutine(songId));
  }

  IEnumerator GetSongCoroutine(int songId)
  {
    string url = "http://153.127.202.28:3000/api/v1/song_info?song_id=" + songId.ToString();
    UnityWebRequest request = UnityWebRequest.Get(url);

    yield return request.Send();

    if (request.isError)
    {
      Debug.Log(request.error);
    }
    else
    {
      if (request.responseCode == 200)
      {
        string text = request.downloadHandler.text;
        Debug.Log(text);
      }
    }
  }
}
