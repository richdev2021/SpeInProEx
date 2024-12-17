using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSwitcher : MonoBehaviour
{
    [SerializeField]public Image ownImage;
    [SerializeField]public Sprite[] imageCollection;
    public void switchImage(int a) {
        ownImage.sprite = imageCollection[a-1];
    }
}
