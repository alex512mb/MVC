using UnityEngine;


public class LightsComposition : MonoBehaviour
{
    private void Start()
    {
        LightsData lightsData = new LightsData();
        
        ILightsView lightsview = GetComponentInChildren<ILightsView>();
        if (lightsview == null)
        {
            Debug.LogError("lightsview not attached");
        }
        lightsview.Initialize(lightsData);
        
        ILightsController lightsController = GetComponentInChildren<ILightsController>();
        if (lightsController == null)
        {
            Debug.LogError("lightsController not attached");
        }
        lightsController.Initialize(lightsData);
    }
}
