﻿// Decompiled with JetBrains decompiler
// Type: MusicBoxContainerCivs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

#nullable disable
public class MusicBoxContainerCivs
{
  public MusicAsset asset;
  public int buildings;
  public bool kingdom_exists;
  public bool active;

  public void clear()
  {
    this.buildings = 0;
    this.kingdom_exists = false;
    this.active = false;
  }
}
