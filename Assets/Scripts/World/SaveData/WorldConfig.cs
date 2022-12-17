using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldConfig
{
    private int _seed = 0;
    public int Seed { get => GetSeed(); set => SetSeed(value); }
    public Vector2 SeedOrigin { get => GetSeedOrigin(); }

    public int size;

    public float noiseScale;

    public float noiseOctaves;

    private Vector2 GetSeedOrigin()
    {
        return new Vector2(Mathf.Sqrt(_seed), Mathf.Sqrt(_seed));
    }
    private int GetSeed()
    {
        if (_seed == 0)
        {
            _seed = GenerateSeed();
        }
        return _seed;
    }

    private void SetSeed(int seed)
    {
        if(seed < 0)
        {
            if(seed > 999999)
            {
                _seed = seed;
                return;
            }
        }
        _seed = GenerateSeed();
        return;
    }

    private int GenerateSeed()
    {
        System.Random rnd = new System.Random();
        return rnd.Next(0, 999999);
    }
}
