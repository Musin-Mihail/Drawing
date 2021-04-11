using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public class TestMask : UIBehaviour, ICanvasRaycastFilter, IMaterialModifier
{
    [NonSerialized]
    private RectTransform m_RectTransform;
    private Graphic m_Graphic;
    private Material m_MaskMaterial;
    private Material m_UnmaskMaterial;
    private bool m_ShowMaskGraphic = true;
    public RectTransform rectTransform
    {
        get { return m_RectTransform ?? (m_RectTransform = GetComponent<RectTransform>()); }
    }
    public bool showMaskGraphic
    {
        get { return m_ShowMaskGraphic; }
        set
        {
            if (m_ShowMaskGraphic == value)
                return;

            m_ShowMaskGraphic = value;
            if (graphic != null)
                graphic.SetMaterialDirty();
        }
    }
    public Graphic graphic
    {
        get { return m_Graphic ?? (m_Graphic = GetComponent<Graphic>()); }
    }  
    protected TestMask()
    {}
    public virtual bool MaskEnabled() { return IsActive() && graphic != null; }
    public virtual void OnSiblingGraphicEnabledDisabled() {}
    protected override void OnEnable()
    {
        base.OnEnable();
        if (graphic != null)
        {
            graphic.canvasRenderer.hasPopInstruction = true;
            graphic.SetMaterialDirty();
            if (graphic is MaskableGraphic)
                (graphic as MaskableGraphic).isMaskingGraphic = true;
        }
        MaskUtilities.NotifyStencilStateChanged(this);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if (graphic != null)
        {
            graphic.SetMaterialDirty();
            graphic.canvasRenderer.hasPopInstruction = false;
            graphic.canvasRenderer.popMaterialCount = 0;

            if (graphic is MaskableGraphic)
                (graphic as MaskableGraphic).isMaskingGraphic = false;
        }

        StencilMaterial.Remove(m_MaskMaterial);
        m_MaskMaterial = null;
        StencilMaterial.Remove(m_UnmaskMaterial);
        m_UnmaskMaterial = null;

        MaskUtilities.NotifyStencilStateChanged(this);
    }

#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();

        if (!IsActive())
            return;

        if (graphic != null)
        {
            // Default the graphic to being the maskable graphic if its found.
            if (graphic is MaskableGraphic)
                (graphic as MaskableGraphic).isMaskingGraphic = true;

            graphic.SetMaterialDirty();
        }

        MaskUtilities.NotifyStencilStateChanged(this);
    }
#endif
    public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (!isActiveAndEnabled)
            return true;

        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, sp, eventCamera);
    }
    public virtual Material GetModifiedMaterial(Material baseMaterial)
    {
        if (!MaskEnabled())
            return baseMaterial;

        var rootSortCanvas = MaskUtilities.FindRootSortOverrideCanvas(transform);
        var stencilDepth = MaskUtilities.GetStencilDepth(transform, rootSortCanvas);
        if (stencilDepth >= 8)
        {
            Debug.LogWarning("Attempting to use a stencil mask with depth > 8", gameObject);
            return baseMaterial;
        }

        int desiredStencilBit = 1 << stencilDepth;

        // if we are at the first level...
        // we want to destroy what is there
        if (desiredStencilBit == 1)
        {
            var maskMaterial = StencilMaterial.Add(baseMaterial, 1, StencilOp.Replace, CompareFunction.Always, m_ShowMaskGraphic ? ColorWriteMask.All : 0);
            StencilMaterial.Remove(m_MaskMaterial);
            m_MaskMaterial = maskMaterial;

            var unmaskMaterial = StencilMaterial.Add(baseMaterial, 1, StencilOp.Zero, CompareFunction.Always, 0);
            StencilMaterial.Remove(m_UnmaskMaterial);
            m_UnmaskMaterial = unmaskMaterial;
            graphic.canvasRenderer.popMaterialCount = 1;
            graphic.canvasRenderer.SetPopMaterial(m_UnmaskMaterial, 0);

            return m_MaskMaterial;
        }

        //otherwise we need to be a bit smarter and set some read / write masks
        var maskMaterial2 = StencilMaterial.Add(baseMaterial, desiredStencilBit | (desiredStencilBit - 1), StencilOp.Replace, CompareFunction.Equal, m_ShowMaskGraphic ? ColorWriteMask.All : 0, desiredStencilBit - 1, desiredStencilBit | (desiredStencilBit - 1));
        StencilMaterial.Remove(m_MaskMaterial);
        m_MaskMaterial = maskMaterial2;

        graphic.canvasRenderer.hasPopInstruction = true;
        var unmaskMaterial2 = StencilMaterial.Add(baseMaterial, desiredStencilBit - 1, StencilOp.Replace, CompareFunction.Equal, 0, desiredStencilBit - 1, desiredStencilBit | (desiredStencilBit - 1));
        StencilMaterial.Remove(m_UnmaskMaterial);
        m_UnmaskMaterial = unmaskMaterial2;
        graphic.canvasRenderer.popMaterialCount = 1;
        graphic.canvasRenderer.SetPopMaterial(m_UnmaskMaterial, 0);

        return m_MaskMaterial;
    }
}