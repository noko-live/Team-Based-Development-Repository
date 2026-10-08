using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance;


    public List<GameObject> PlayerStars;
    public Animator CurtainAnimator;
    public RawImage GameRenderTexture;
    public GameObject CameraUI;
    public GameObject PlayerSelectScreen;
    public GameObject TitleScreen;

    Minigame_ManagerScript mg_manager;


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        UIDefaults();
        mg_manager = Minigame_ManagerScript.Instance;
    }




    void UIDefaults()
    {
        HideStars();
        TitleScreen.SetActive(true);
    }


    public void ShowPlayerSelect()
    {
        CameraUI.SetActive(false);
        TitleScreen.SetActive(false);


        PlayerSelectScreen.SetActive(true);
    }

    [ContextMenu("MakeCurtainGoUp")]
    public void MakeCurtainGoUp()
    {
        CurtainAnimator.SetTrigger("CurtainUp");
    }

    [ContextMenu("MakeCurtainGoDown")]
    public void MakeCurtainGoDown()
    {
        CurtainAnimator.SetTrigger("CurtainDown");
    }


    [ContextMenu("Hide Stars")]
    public void HideStars()
    {
        foreach (GameObject obj in PlayerStars)
        {
            obj.GetComponent<StarUIScript>().Hide();
        }
    }

    [ContextMenu("Show Stars")]
    public void ShowStars()
    {
        foreach (GameObject obj in PlayerStars)
        {
            obj.GetComponent<StarUIScript>().Show();
        }
    }


    public void HideTitle()
    {
        TitleScreen.SetActive(false);
    }

    public void ShowTitle()
    {
        TitleScreen.SetActive(true);
    }


    public void PlayerSelectReady()
    {
        TitleScreen.SetActive(false);
        PlayerSelectScreen.SetActive(false);
        CameraUI.SetActive(true);

        mg_manager.StartGame();
    }



}
