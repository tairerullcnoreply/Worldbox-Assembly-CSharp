﻿// Decompiled with JetBrains decompiler
// Type: Blacklist
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EAF20368-35E7-4BB6-B082-5477D61019A6
// Assembly location: C:\Users\Takko\Downloads\Worldbox .NET\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class Blacklist
{
  private static readonly Dictionary<string, string[]> _profanity = new Dictionary<string, string[]>();
  private const int INDEX_LENGTH = 3;
  private static bool _initiated = false;

  public static void init()
  {
    if (Blacklist._initiated)
      return;
    Blacklist._initiated = true;
    BlacklistTools.loadProfanityFilter(Blacklist._profanity);
  }

  internal static bool checkBlackList(StringBuilderPool pName)
  {
    pName.ToLowerInvariant();
    Span<char> destination = stackalloc char[pName.Length];
    pName.CopyTo(0, destination, pName.Length);
    ReadOnlySpan<char> readOnlySpan1 = Span<char>.op_Implicit(destination);
    Dictionary<string, string[]> profanity = Blacklist._profanity;
    ReadOnlySpan<char> readOnlySpan2;
    for (int pStartIndex = 0; pStartIndex < readOnlySpan1.Length - 3 + 1; ++pStartIndex)
    {
      readOnlySpan2 = readOnlySpan1.Slice(pStartIndex, 3);
      string key = readOnlySpan2.ToString();
      string[] strArray;
      if (profanity.TryGetValue(key, out strArray))
      {
        for (int index = 0; index < strArray.Length; ++index)
        {
          ReadOnlySpan<char> pSearchPattern = MemoryExtensions.AsSpan(strArray[index]);
          if (BlacklistTools.contains(readOnlySpan1, pSearchPattern, pStartIndex))
            return true;
        }
      }
    }
    ReadOnlySpan<char> pText = BlacklistTools.cleanSpan(readOnlySpan1);
    if ((ReadOnlySpan<char>.op_Equality(pText, readOnlySpan1) ? 0 : (pText.Length > 2 ? 1 : 0)) == 0)
      return false;
    for (int pStartIndex = 0; pStartIndex < pText.Length - 3 + 1; ++pStartIndex)
    {
      readOnlySpan2 = pText.Slice(pStartIndex, 3);
      string key = readOnlySpan2.ToString();
      string[] strArray;
      if (profanity.TryGetValue(key, out strArray))
      {
        for (int index = 0; index < strArray.Length; ++index)
        {
          ReadOnlySpan<char> pSearchPattern = MemoryExtensions.AsSpan(strArray[index]);
          if (BlacklistTools.contains(pText, pSearchPattern, pStartIndex))
            return true;
        }
      }
    }
    return false;
  }

  internal static bool checkBlackList(string pName)
  {
    ReadOnlySpan<char> readOnlySpan1 = MemoryExtensions.AsSpan(pName.ToLower());
    Dictionary<string, string[]> profanity = Blacklist._profanity;
    ReadOnlySpan<char> readOnlySpan2;
    for (int pStartIndex = 0; pStartIndex < readOnlySpan1.Length - 3 + 1; ++pStartIndex)
    {
      readOnlySpan2 = readOnlySpan1.Slice(pStartIndex, 3);
      string key = readOnlySpan2.ToString();
      string[] strArray;
      if (profanity.TryGetValue(key, out strArray))
      {
        for (int index = 0; index < strArray.Length; ++index)
        {
          ReadOnlySpan<char> pSearchPattern = MemoryExtensions.AsSpan(strArray[index]);
          if (BlacklistTools.contains(readOnlySpan1, pSearchPattern, pStartIndex))
            return true;
        }
      }
    }
    ReadOnlySpan<char> pText = BlacklistTools.cleanSpan(readOnlySpan1);
    if ((ReadOnlySpan<char>.op_Equality(pText, readOnlySpan1) ? 0 : (pText.Length > 2 ? 1 : 0)) == 0)
      return false;
    for (int pStartIndex = 0; pStartIndex < pText.Length - 3 + 1; ++pStartIndex)
    {
      readOnlySpan2 = pText.Slice(pStartIndex, 3);
      string key = readOnlySpan2.ToString();
      string[] strArray;
      if (profanity.TryGetValue(key, out strArray))
      {
        for (int index = 0; index < strArray.Length; ++index)
        {
          ReadOnlySpan<char> pSearchPattern = MemoryExtensions.AsSpan(strArray[index]);
          if (BlacklistTools.contains(pText, pSearchPattern, pStartIndex))
            return true;
        }
      }
    }
    return false;
  }
}
