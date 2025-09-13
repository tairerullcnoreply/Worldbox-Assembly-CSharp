﻿// Decompiled with JetBrains decompiler
// Type: ai.behaviours.BehCityActorCreateRoad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

#nullable disable
namespace ai.behaviours;

public class BehCityActorCreateRoad : BehCityActor
{
  protected override void setupErrorChecks()
  {
    base.setupErrorChecks();
    this.null_check_tile_target = true;
  }

  public override BehResult execute(Actor pActor)
  {
    MapAction.createRoadTile(pActor.beh_tile_target);
    pActor.addLoot(SimGlobals.m.coins_for_road);
    return BehResult.Continue;
  }
}
