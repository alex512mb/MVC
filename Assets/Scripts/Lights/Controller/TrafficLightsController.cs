using System.Collections;
using UnityEngine;


public class TrafficLightsController : MonoBehaviour, ILightsController
{
    public float redLightDuration = 6;
    public float orangeLightDuration = 2;
    public float greenLightDuration = 4;
    public float greenSignalDuration = 0.3f;

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
            lightsData.EnableLight(0);
            yield return new WaitForSeconds(redLightDuration);

            lightsData.EnableLight(1);
            yield return new WaitForSeconds(orangeLightDuration);

            lightsData.DisableLight(0);
            lightsData.DisableLight(1);
            lightsData.EnableLight(2);

            yield return new WaitForSeconds(greenLightDuration);
            lightsData.DisableLight(2);

            //alarm signals green
            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(greenSignalDuration);
                lightsData.EnableLight(2);
                yield return new WaitForSeconds(greenSignalDuration);
                lightsData.DisableLight(2);
            }

        }
    }

}
