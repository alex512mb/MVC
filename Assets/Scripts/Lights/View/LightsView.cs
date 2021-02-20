using UnityEngine;


public class LightsView : MonoBehaviour, ILightsView
{
    [SerializeField] private ILightView[] lights = default;

    private LightsData lightsData;


    public void Initialize(LightsData lightsData)
    {
        this.lightsData = lightsData;
        CollectLights();
        LoadLightsState();
        SetupEventHandlers();
    }

    private void CollectLights()
    {
        lights = GetComponentsInChildren<ILightView>(); 
    }

    private void LoadLightsState()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            UpdateLight(i, lightsData.IsEnabled(i));
        }
    }

    private void SetupEventHandlers()
    {
        lightsData.OnLightStateChanged += LightsData_OnLightStateChanged;
    }

    private void UpdateLight(int lightIndex, bool lightEnabled)
    {
        lights[lightIndex].SetActive(lightEnabled);
    }

    private void LightsData_OnLightStateChanged(int lightIndex, bool lightEnabled)
    {
        if (lightIndex >= lights.Length)
        {
            Debug.LogWarning("light index out of range");
            return;
        }

        UpdateLight(lightIndex, lightEnabled);
    }

}
