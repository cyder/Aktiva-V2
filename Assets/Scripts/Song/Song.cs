using System.Collections.Generic;
using UnityEngine;

namespace SongUtility
{
  public class Song
  {
    int songId; // 曲ID
    string _title; // 曲タイトル
    string _artist; // アーティスト名
    string url; //動画URL
    bool isLoad = false;
    DanceScore danceScore; // 採点
    Movie movie; // 動画
    List<Lyric> lyrics = new List<Lyric>();

    public string title
    {
      get
      {
        return _title;
      }

      private set
      {
        _title = value;
      }
    }


    public string artist
    {
      get
      {
        return _artist;
      }

      private set
      {
        _artist = value;
      }
    }

    public bool IsLoad
    {
      get
      {
        return isLoad;
      }

      private set
      {
        isLoad = value;
      }
    }

    public string Url
    {
      get
      {
        return url;
      }

      private set
      {
        url = value;
      }
    }
    public Song(int id)
    {
      danceScore = new DanceScore();
      movie = new Movie();
      songId = id;

      // 仮実装、本来ならサーバにデータを取りに行く
      WebRequestManager webRequestManager = GameObject.Find("WebRequestManager").GetComponent<WebRequestManager>();
      webRequestManager.GetSongData(songId, SetSongData);

      for (int i = 0; i < 20; i++)
      {
        string text = string.Format("歌詞{0}", i);
        string time = string.Format("0:{0}:0", i);
        lyrics.Add(new Lyric(text, time));
      }
    }

    void SetSongData(SongJson songJson)
    {
      title = songJson.title;
      artist = songJson.artist.name;
      Url = "http://133.242.226.13/" + songJson.video;
      IsLoad = true;
    }

    public Lyric GetLyric(int index)
    {
      return lyrics[index];
    }
  }
}