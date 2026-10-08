using UnityEngine;
using UnityEngine.UI;

public class StarUIScript : MonoBehaviour
{
    
    
    /*

    //Leftover code for attempting to animate the stars movements

    Vector3 targetPos;
    enum HideDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    HideDirection _HideDirection = HideDirection.UP;
    */


    public void Hide()
    {
        gameObject.SetActive(false);

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    void CheckDirection()
    {
        /*
        Vector3 starPos;

        switch (_HideDirection)
        {
            case _HideDirection.UP:
            targetPos = new Vector3 (tranform.position.x, tranform.position.y + 50f, tranform.position.z);
            break;
            
            case _HideDirection.DOWN:
            targetPos = new Vector3 (tranform.position.x, tranform.position.y + -50f,tranform.position.z);
            break;            
            
            case _HideDirection.RIGHT:
            targetPos = new Vector3 (tranform.position.x, tranform.position.y + 50f, tranform.position.z);
            break;            
            
            case _HideDirection.LEFT:
            targetPos = new Vector3 (tranform.position.x, tranform.position.y + 50f, tranform.position.z);
            break;
            
        }
        */
    }

}
