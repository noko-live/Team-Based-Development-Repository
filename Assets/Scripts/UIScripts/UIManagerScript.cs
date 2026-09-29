using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class UIManagerScript : MonoBehaviour
{

    public List<GameObject> PlayerStars;

    void Start() 
    {
        UIDefaults();    
    }

    [ContextMenu("Hide Stars")]
    void HideStars()
    {
        foreach (GameObject obj in PlayerStars)
        {
            obj.GetComponent<StarUIScript>().Hide();
        }
    }

    [ContextMenu("Show Stars")]
    void ShowStars()
    {
        foreach (GameObject obj in PlayerStars)
        {
            obj.GetComponent<StarUIScript>().Show();
        }
    }


    void UIDefaults()
    {
        HideStars();
    }


}
