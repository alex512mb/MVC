using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLightsController : MonoBehaviour, ILightsController
{
    [SerializeField] private int lightsCount = 3;
    [SerializeField] private float lightActiveDuration = 0.2f;

    private int selectedLightIndex = 0;
    private int nextLightIndex = 1;
    private LightsData lightsData;


    public void Initialize(LightsData lightsData)
    {
        this.lightsData = lightsData;
        StartCoroutine(LightsProgramm());
    }

    private IEnumerator LightsProgramm()
    {
        while (true)
        {
            for (int i = 0; i < lightsCount; i++)
            {
                lightsData.EnableLight(selectedLightIndex);
                yield return new WaitForSeconds(lightActiveDuration);
                lightsData.DisableLight(selectedLightIndex);
                //lightsData.EnableLight(nextLightIndex);

                SelectNextLight();
            }
        }
    }

    private void SelectNextLight()
    {
        selectedLightIndex = nextLightIndex;

        nextLightIndex++;

        if (nextLightIndex >= lightsCount)
            nextLightIndex = 0;
    }
}
