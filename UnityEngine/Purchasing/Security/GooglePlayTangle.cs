﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.Purchasing.Security.GooglePlayTangle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

using System;

#nullable disable
namespace UnityEngine.Purchasing.Security;

public class GooglePlayTangle
{
  private static byte[] data = Convert.FromBase64String("dMZFZnRJQk1uwgzCs0lFRUVBREdEmfRYkbtqgRbn1uonvTwN/R8KFU6dxJq3OX0iF3cfyyJx8SV7RVGGxkVLRHTGRU5GxkVFRP5Y/5bFSR/VDy6kDuoXivfvEGyjKBQT+9rZmVyqpLrINBBIHwrgnBmw5oYPgCTQFfAkFYtqkxQ7rApQgWXHUO1Yazc8LKUBLugsGw9EnuaTejink6/77p3l5I8yLPPXoWzpZiaKULv3J2oWZA/rW+FQV6LIhhRwCV/P+f9WmvYdd6ZmDDpkn3tjgD+VREl/ATD2fsHxO5PI/rKsCQMWxPlMIo8bIhQj7mVfsjIQHaUvOw4F+T5WKYoyovWQkU1OkQpSqXwrq6UIHOp9hHP01aTEwqMk21zFcUZHRURF");
  private static int[] order = new int[15]
  {
    0,
    6,
    8,
    6,
    11,
    8,
    7,
    9,
    12,
    12,
    10,
    11,
    13,
    13,
    14
  };
  private static int key = 68;
  public static readonly bool IsPopulated = true;

  public static byte[] Data()
  {
    return !GooglePlayTangle.IsPopulated ? (byte[]) null : Obfuscator.DeObfuscate(GooglePlayTangle.data, GooglePlayTangle.order, GooglePlayTangle.key);
  }
}
