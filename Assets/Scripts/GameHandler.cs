using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private ButtonsController buttonsController;
    void Awake()
    {
        buttonsController = new ButtonsController();
        buttonsController.Begin();
    }   
}
