using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class LightViewRenderer : MonoBehaviour, ILightView
{
    private Renderer attachedRender;

    private void Awake()
    {
        attachedRender = GetComponent<Renderer>();
    }
    public void SetActive(bool active)
    {
        attachedRender.enabled = active;
    }
}
