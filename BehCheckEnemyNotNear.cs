﻿// Decompiled with JetBrains decompiler
// Type: BehCheckEnemyNotNear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

using ai.behaviours;

#nullable disable
public class BehCheckEnemyNotNear : BehaviourActionActor
{
  public override BehResult execute(Actor pActor)
  {
    return Finder.isEnemyNearOnSameIsland(pActor) ? BehResult.Stop : BehResult.Continue;
  }
}
