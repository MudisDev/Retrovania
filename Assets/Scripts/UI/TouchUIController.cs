using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class TouchUIController : MonoBehaviour
{
    public static TouchUIController sharedInstance;

    [SerializeField] Image actionButton;
    [SerializeField] Image attackButton;
    [SerializeField] Image jumpButton;
    //[SerializeField] Image pauseButton;
    [SerializeField] Image leftButton;
    [SerializeField] Image rightButton;

    private void Awake()
    {
        sharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.actionButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.sharedInstance.GetIsAttacking())
        {
            //this.attackButton.enabled = false;


            Color attackPressed;
            ColorUtility.TryParseHtmlString("#9E0F20", out attackPressed);
            this.attackButton.color = attackPressed;
            /*  

             

             Color movePressed;
             ColorUtility.TryParseHtmlString("#347C26", out movePressed);

             Color actionPressed;
             ColorUtility.TryParseHtmlString("#879326", out actionPressed); */
        }
        else
            //this.attackButton.enabled = true;
            this.attackButton.color = Color.white;

        if (PlayerController.sharedInstance.GetIsTouchingTheGround())
            this.jumpButton.color = Color.white;
        else
        {
            Color jumpPressed;
            ColorUtility.TryParseHtmlString("#1C968A", out jumpPressed);
            this.jumpButton.color = jumpPressed;
        }

        /*  if (GameManager.sharedInstance.currentGameState == GameState.pause)
         {
             Color pausePressed;
             ColorUtility.TryParseHtmlString("#8A3A99", out pausePressed);
             this.pauseButton.color = pausePressed;
         }
         else
         {
             this.pauseButton.color = Color.white;
         } */


        Vector2 moveInput = InputManager.sharedInstance.GetMovementX();
        float direction = moveInput.x;
        //float moveX = 0f;

        if (direction > 0)
        {
            Color movePressed;
            ColorUtility.TryParseHtmlString("#347C26", out movePressed);
            rightButton.color = movePressed;
        }
        else
        {
            rightButton.color = Color.white;
        }
        if (direction < 0)
        {
            Color movePressed;
            ColorUtility.TryParseHtmlString("#347C26", out movePressed);
            leftButton.color = movePressed;
        }
        else
            leftButton.color = Color.white;

    }
    public void SetActionButton(bool status)
    {
        this.actionButton.enabled = status;
    }
}
