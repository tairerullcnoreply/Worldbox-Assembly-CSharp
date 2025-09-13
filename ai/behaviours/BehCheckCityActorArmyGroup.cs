﻿// Decompiled with JetBrains decompiler
// Type: ai.behaviours.BehCheckCityActorArmyGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

#nullable disable
namespace ai.behaviours;

public class BehCheckCityActorArmyGroup : BehCitizenActionCity
{
  public override BehResult execute(Actor pActor)
  {
    if (!pActor.isKingdomCiv())
    {
      pActor.stopBeingWarrior();
      return BehResult.Stop;
    }
    if (pActor.city.hasArmy())
    {
      Army army = pActor.city.army;
      if (army.isGroupInCityAndHaveLeader())
        pActor.setArmy(army);
    }
    return BehResult.Continue;
  }
}
