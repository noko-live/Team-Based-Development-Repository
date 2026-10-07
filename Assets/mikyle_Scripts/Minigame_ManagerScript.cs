using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Linq;

public class Minigame_ManagerScript : MonoBehaviour
{

    public static Minigame_ManagerScript Instance;

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
    public enum gameList
    {
        PopTheLock,
        CanonSprint
    }

    gameList _currentgame;

    public List<Texture> gameRenderTextureList;
    UIManagerScript uimanager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        uimanager = UIManagerScript.Instance;
    }

    public void StartGame()
    {
        uimanager.MakeCurtainGoUp();
        LoadGame(RandomGame());
    }


    gameList RandomGame()
    {
        _currentgame = (gameList)UnityEngine.Random.Range(0, (int)Enum.GetValues(typeof(gameList)).Cast<gameList>().Max());
        return _currentgame;        
    }




    void LoadGame(gameList game)
    {
        switch (game)
        {
            case gameList.PopTheLock:
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
                uimanager.GameRenderTexture.texture = gameRenderTextureList[0];
                break;

            case gameList.CanonSprint:
                SceneManager.LoadScene("CannonSprint", LoadSceneMode.Additive);
                uimanager.GameRenderTexture.texture = gameRenderTextureList[1];
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
