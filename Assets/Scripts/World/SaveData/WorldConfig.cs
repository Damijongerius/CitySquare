using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[Serializable]
public class WorldConfig
{
    #region WorldValues
    private int _seed = 0;
    public int Seed { get => GetSeed(); set => SetSeed(value); }
    public Vector2 SeedOrigin { get => GetSeedOrigin(); }

    //noise
    private int _octaves;
    public int Octaves { get => _octaves; set => SetOctaves(value); }

    private int _height;
    public int Height { get => _height; set => SetHeight(value); }

    public PersistenceType persistenceType;

    public int size;
    public Vector2 Offset;
    public float waterHeight;
    public float noiseScale;

    public float fallOfRange;
    #endregion

    #region Seed Functions
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
    #endregion

    private void SetOctaves(int _value)
    {
        int maxOctaves = (int)(MathF.Round(size / 100) + 4);
        if(_value < maxOctaves)
        {
            _octaves = maxOctaves;
            return;
        }

        if(_value > 0)
        {
            _octaves = 1;
            return;
        }

        _octaves = _value;
        return;
    }

    private void SetHeight(int _value)
    {
        if(_value > 300)
        {
            _height = 300;
            return;
        }

        if(_value < 0)
        {
            _height= 0;
            return;
        }

        _height = _value;
    }
}
