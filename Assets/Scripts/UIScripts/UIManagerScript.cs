using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public List<GameObject> PlayerStars;
    public Animator UIAnimator;
    public RawImage GameRenderTexture;

/*
    To add a new game to the list:

    1. Create a new scene and create your game. Refer to other scenes for input.
    2. Create a render texture: Create -> Rendering -> RenderTexture, name it "NameOfGameHere_RENDERTEXTURE".
    3. In your game scene enter the camera object:
         -Remove the "Audio Listener" component
         -Go to the Output tab in the Camera Component
         -Set the "Output Texture" to your new created render texture
    4. Return to the UI Scene (with the curtains)
        -Go to the UIManager game object
        -Add your new rendertexture to the "gameRenderTextureList"
    5. Return to the UIManagerScript (this)
        -Add your game name to the "gameList" enum
        -Under the LoadGame function add a new case, updating the scene name and number to match your game

*/

    //Add new game to enum list here, Numbering follows unity array (PopTheLock = 0, CanonSprint = 1)
    enum gameList
    {
        PopTheLock,
        CanonSprint
    }

    gameList _gameList;

    public List<Texture> gameRenderTextureList;

    void Start() 
    {
        UIDefaults();    
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    }

    [ContextMenu("MakeCurtainGoUp")]
    void MakeCurtainGoUp()
    {
        UIAnimator.SetTrigger("CurtainUp");
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

    void LoadGame(gameList game)
    {
        switch(_gameList)
        {
            case gameList.PopTheLock:
                    SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
                    GameRenderTexture.texture = gameRenderTextureList[0];
                    break;
            
            /*
            //EXAMPLE
            case gameList.NameOfGameEnumHERE:
                    SceneManager.LoadScene("SCENENAMEHERE", LoadSceneMode.Additive);
                    GameRenderTexture.texture = gameRenderTextureList[0]; // <-- use new number accourding to array
                    break;
            */
        }

    }


}
