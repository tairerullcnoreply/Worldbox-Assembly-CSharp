﻿// Decompiled with JetBrains decompiler
// Type: DebugToolAsset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class DebugToolAsset : Asset
{
  public string name;
  public string benchmark_group_id = string.Empty;
  public string benchmark_total = string.Empty;
  public string benchmark_total_group = string.Empty;
  public string path_icon;
  public int priority;
  public DebugToolType type;
  public DebugToolAssetAction action_1;
  public DebugToolAssetAction action_2;
  public DebugToolAssetAction action_start;
  public DebugToolUpdateDelegate action_update;
  public float update_timeout = 0.1f;
  public bool show_on_start;
  public bool show_benchmark_buttons;
  public bool split_benchmark;
  public bool show_last_count;

  public void showForMaxim()
  {
    if (!Config.editor_maxim)
      return;
    this.show_on_start = Config.editor_maxim;
  }

  public void showForMastef()
  {
    if (!Config.editor_mastef)
      return;
    this.show_on_start = Config.editor_mastef;
  }

  public void showForNikon()
  {
    if (!Config.editor_nikon)
      return;
    this.show_on_start = Config.editor_nikon;
  }
}
