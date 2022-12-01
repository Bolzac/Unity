using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour
{
    protected GameObject VisualSlider;
    
    private void Awake()
    {
        if (transform.Find("VisualSliderR").gameObject != null)
        {
            VisualSlider = transform.Find("VisualSliderR").gameObject;
        }
        else
        {
            VisualSlider = transform.Find("VisualSliderL").gameObject; 
        }
    }
}
