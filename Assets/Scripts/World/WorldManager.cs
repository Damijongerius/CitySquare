using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    #region General

    [Header("General Settings")]
    public int mapSize = 100;

    [Space(100)]
    public int seed = 0;
    public int noiseScale = 1;
    public float maxHeight = 256f;

    [Space(100)]
    [Header("Water Settings")]

    public float waterLevel;

    private WorldConfig worldConfig;


    #endregion

}
