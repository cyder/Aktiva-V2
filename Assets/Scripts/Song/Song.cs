using System;
using System.Collections.Generic;

namespace SongUtility
{
  public class Song
  {
    int songId; // 曲ID
    string _title; // 曲タイトル
    string _artist; // アーティスト名
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

    public Song(int id)
    {
      danceScore = new DanceScore();
      movie = new Movie();
      songId = id;

      // 仮実装、本来ならサーバにデータを取りに行く
      title = string.Format("曲名{0}", songId);
      artist = string.Format("アーティスト{0}", songId);

      for (int i = 0; i < 20; i++)
      {
        string text = string.Format("歌詞{0}", i);
        string time = string.Format("0:{0}:0", i);
        lyrics.Add(new Lyric(text, time));
      }
    }

    public Lyric GetLyric(int index)
    {
      return lyrics[index];
    }
  }
}