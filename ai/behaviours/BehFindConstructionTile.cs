﻿// Decompiled with JetBrains decompiler
// Type: ai.behaviours.BehFindConstructionTile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

#nullable disable
namespace ai.behaviours;

public class BehFindConstructionTile : BehActorBuildingTarget
{
  public override BehResult execute(Actor pActor)
  {
    pActor.beh_tile_target = pActor.beh_building_target.getConstructionTile();
    return BehResult.Continue;
  }
}
