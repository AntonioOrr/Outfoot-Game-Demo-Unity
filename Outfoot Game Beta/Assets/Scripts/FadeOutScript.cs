using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    public float fadeDelay = 1f;
    public float alphaValue = 0;

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    IEnumerator FadeOut(float aValue, float fadeTime)
    {
        float alpha = rend.color.a;
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime)
        {
            Color newColor = new Color(rend.color.r, rend.color.g, rend.color.b, Mathf.Lerp(alpha, aValue, t));
            rend.color = newColor;
            yield return null;
            
        }
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
