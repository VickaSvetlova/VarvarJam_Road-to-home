using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFade : MonoBehaviour {

    [SerializeField] private float alpha = 1f;
    [SerializeField] private float speed = .015f;

    Renderer[] renderers;

    private void Start() {
        renderers = GetComponentsInChildren<Renderer>();
        //foreach (var renderer in renderers) {
        //    renderer.sharedMaterial
        //}
    }

    [ContextMenu("Fade")]
    public void Fade() {
        StartCoroutine(IEFade(true));
    }

    [ContextMenu("Show")]
    public void Show() {
        StartCoroutine(IEFade(false));
    }

    IEnumerator IEFade(bool fade) {
        float targetAlpha = fade ? 0f : 1f;
        while (alpha != targetAlpha) {
            SetAlpha(Mathf.MoveTowards(alpha, targetAlpha, speed));
            yield return new WaitForSeconds(.02f);
        }
        SetShadow(!fade);
    }

    void SetAlpha(float alpha) {
        this.alpha = alpha;
        foreach (var renderer in renderers) {
            renderer.material.SetFloat("GhostAlpha", alpha);
        }
    }

    void SetShadow(bool shadow) {
        UnityEngine.Rendering.ShadowCastingMode mode = shadow 
            ? UnityEngine.Rendering.ShadowCastingMode.On 
            : UnityEngine.Rendering.ShadowCastingMode.Off;
        foreach (var renderer in renderers) {
            renderer.shadowCastingMode = mode;
        }
    }

}
