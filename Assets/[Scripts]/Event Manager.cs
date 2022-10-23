using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private bool gameJustStarted;
    private bool ableToPlaceBar = false;
    private bool placedbar = false;
    private bool prepPhase = false;
    private bool gamePhase = false;
    private bool afterPhase = false;
    void Start()
    {
        gameJustStarted = true;
    }

    void Update()
    {
        //game starts, be able to place barracks

        if (gameJustStarted)
        {
            ableToPlaceBar = true;
        }

        //after placed barracks, you arent allowed to place again, menu pops up

        if (ableToPlaceBar && placedbar)
        {
            afterPhase = true;

            //if (continueButtonPressed)
            //{
            //    afterPhase = false;
            //    prepPhase = true;
            //}


        }

        //after shop purchase, prep phase (be able to place the things you purchased)

        if (!afterPhase && prepPhase)
        {
            //initiate prep phase

            //possibly have the user press space or time runs out to go onto game phasse aka gamephase = true and prepphase = false;
        }

        //after prep phase, game phase (defend)

        if (!prepPhase && gamePhase)
        {
            //FIGHT
        }

        //after game phase, after phase (shop menu)

        if (!gamePhase && afterPhase)
        {
            //shop time
        }

        //after after phase, prep phase. Repeat the cycle.


    }

    
}
