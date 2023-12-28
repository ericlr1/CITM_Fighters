using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageButton : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeButton()
    {
        button.image.sprite = newButtonImage;
    }
}
