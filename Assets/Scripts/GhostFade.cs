using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFade : MonoBehaviour {

    private float alpha = 1f;

    Renderer[] renderers;

    private void Start() {
        renderers = GetComponentsInChildren<Renderer>();
        //foreach (var renderer in renderers) {
        //    renderer.sharedMaterial
        //}
    }

    public void Fade(bool fade) {
        StartCoroutine(IEFade(fade ? 0f : 1f));
    }

    IEnumerator IEFade(float targetAlpha) {
        while (alpha != targetAlpha) {
            SetAlpha(Mathf.MoveTowards(alpha, targetAlpha, .02f));
            yield return new WaitForSeconds(.02f);
        }
    }

    void SetAlpha(float alpha) {
        this.alpha = alpha;
        foreach (var renderer in renderers) {
            renderer.material.SetFloat("GhostAlpha", alpha);
        }
    }

}
