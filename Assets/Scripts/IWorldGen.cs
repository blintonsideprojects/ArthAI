using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public interface IWorldGen
{
    void Apply(TilemapStructure tilemap);
}