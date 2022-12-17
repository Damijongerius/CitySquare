using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NoiseGenerator
{

    public WorldConfig worldConfig;

    public NoiseGenerator(WorldConfig _wc)
    {
        this.worldConfig = _wc;
    }

    public void GenerateNoise()
    {

        for (int x = 0, i = 0; x < worldConfig.size; x++)
        {
            for (int y = 0; y < worldConfig.size; y++, i++)
            {
                float a = Noisefunction(x, y);
            }
        }
    }

    private float Noisefunction(float _x, float _y)
    {
        float a = 0, noisesize = worldConfig.noiseScale, opacity = 1;

        for (int octaves = 0; octaves < worldConfig.noiseOctaves; octaves++)
        {
            float xVal = (_x / (noisesize * worldConfig.size)) + worldConfig.SeedOrigin.x;
            float yVal = (_y / (noisesize * worldConfig.size)) - worldConfig.SeedOrigin.y;
            float z = noise.snoise(new float2(xVal, yVal));
            a += Mathf.InverseLerp(0, 1, z) / opacity;

            noisesize /= 2f;
            opacity *= 2f;
        }

        return a -= FallOffMap(_x, _y, worldConfig.size, worldConfig.size / 0.8f);
    }

    private float FallOffMap(float x, float y, int size, float islandSize)
    {
        float gradient = 1;

        gradient /= (x * y) / (size * size) * (1 - (x / size)) * (1 - (y / size));
        gradient -= 16;
        gradient /= islandSize;


        return gradient;
    }

}
