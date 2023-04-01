using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpinner : MonoBehaviour
{
    public FloatReference _rotateSpeed = new FloatReference();
    private RectTransform _rectComponent;
    
    
    void Start()
    {
        _rectComponent = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rectComponent.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
    }
}
