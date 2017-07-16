namespace SongUtility
{
  public class Song
  {
    int songId; // 曲ID
    string title; // 曲タイトル
    string artist; // アーティスト名
    DanceScore danceScore; // 採点
    Movie movie; // 動画

    public Song(int id)
    {
      danceScore = new DanceScore();
      movie = new Movie();
      songId = id;
    }
  }
}