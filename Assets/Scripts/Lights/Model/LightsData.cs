using System;
using System.Collections.Generic;


public class LightsData
{
    public LightsData(params int[] enabledLightIndexes)
    {
        EnableLights(enabledLightIndexes);
    }
    
    public HashSet<int> activeLights = new HashSet<int>();
    public event Action<int, bool> OnLightStateChanged;

    public void EnableLight(int indexLight)
    {
        if (!activeLights.Contains(indexLight))
        {
            activeLights.Add(indexLight);
            OnLightStateChanged?.Invoke(indexLight, true);
        }
    }

    public void EnableLights(params int[] lightIndexes)
    {
        for (int i = 0; i < lightIndexes.Length; i++)
        {
            EnableLight(i);
        }
    }

    public void DisableLight(int indexLight)
    {
        if (activeLights.Contains(indexLight))
        {
            activeLights.Remove(indexLight);
            OnLightStateChanged?.Invoke(indexLight, false);
        }
    }

    public void DisableLights(params int[] lightIndexes)
    {
        for (int i = 0; i < lightIndexes.Length; i++)
        {
            DisableLight(i);
        }
    }

    public bool IsEnabled(int indexLight)
    {
        return activeLights.Contains(indexLight);
    }
}
