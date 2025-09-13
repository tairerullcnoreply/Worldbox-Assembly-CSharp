﻿// Decompiled with JetBrains decompiler
// Type: MapMetaData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable
[Serializable]
public class MapMetaData
{
  [NonSerialized]
  public string temp_date_string = "";
  public int saveVersion;
  public int width;
  public int height;
  public MapStats mapStats;
  public int cities;
  public int units;
  public int population;
  public int structures;
  public int mobs;
  public int vegetation;
  public long deaths;
  public int kingdoms;
  public int buildings;
  public int equipment;
  public int books;
  public int wars;
  public int alliances;
  public int families;
  public int clans;
  public int cultures;
  public int religions;
  public int languages;
  public int subspecies;
  public int favorites;
  public int favorite_items;
  public bool cursed;
  [DefaultValue(false)]
  public bool modded;
  [DefaultValue(null)]
  public List<string> modsActive = new List<string>();
  public double timestamp;

  public void prepareForSave()
  {
    this.modded = Config.MODDED;
    if (this.modded)
      this.modsActive = new List<string>((IEnumerable<string>) ModLoader.getModsLoaded());
    this.timestamp = Epoch.Current();
  }

  public string toJson()
  {
    return JsonConvert.SerializeObject((object) this, new JsonSerializerSettings()
    {
      DefaultValueHandling = (DefaultValueHandling) 3
    });
  }
}
