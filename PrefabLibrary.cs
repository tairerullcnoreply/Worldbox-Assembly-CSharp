﻿// Decompiled with JetBrains decompiler
// Type: PrefabLibrary
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class PrefabLibrary : MonoBehaviour
{
  internal static PrefabLibrary instance;
  public GameObject graphy;
  public DebugTool debugTool;
  public DragonAsset dragonAsset;
  public DragonAsset zombieDragonAsset;
  public Image iconLock;

  private void Awake() => PrefabLibrary.instance = this;
}
