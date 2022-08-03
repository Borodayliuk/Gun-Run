using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PortalLevel
{
    public bool isPoverL;
    public bool isPoverR;
    [Range(-15, 15)]
    public int countL;
    [Range(-15, 15)]
    public int countR;
    [Range(10, 80)]
    public int angleL;
    [Range(10, 80)]
    public int angleR;
}
[Serializable]
public class BlockLevel
{
    [Range(1, 40)]
    public int levelBlock;
    
    public GameObject groupBlocksPrefab;
}

[CreateAssetMenu(fileName ="New Stage")]
public class Stage : ScriptableObject
{
    public List<PortalLevel> portals = new List<PortalLevel>();
    public List<BlockLevel> blocks = new List<BlockLevel>();
}
