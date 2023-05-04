using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SlideCards : MonoBehaviour
{
    [SerializeField] private XRSlider _xrSlider;
    private float _sliderValue;
    private bool _sliding=false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SlidingSetTrue()
    {
        _sliding = true;
    }
    public void SlidingSetFalse()
    {
        _sliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_sliding)SlideCard();
    }

    private void SlideCard()
    {
        _sliderValue = _xrSlider.value;
        transform.position -= new Vector3(0,0,(_sliderValue-0.5f)*0.2f);
    }
}
