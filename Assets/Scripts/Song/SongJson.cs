using System;

[Serializable]
public class SongJson
{
  public int song_id;
  public string title;
  public ArtistJson artist;
  public LyricistJson lyricist;
  public ComposerJson composer;
  public ChoreographerJson choreographer;
  public BadgeJson badge;
  public string video;
}

[Serializable]
public class ArtistJson
{
  public int id;
  public string name;
}

[Serializable]
public class LyricistJson
{
  public int id;
  public string name;
}

[Serializable]
public class ComposerJson
{
  public int id;
  public string name;
}

[Serializable]
public class ChoreographerJson
{
  public int id;
  public string name;
}

[Serializable]
public class BadgeJson
{
  public bool beginners;
  public bool person;
}