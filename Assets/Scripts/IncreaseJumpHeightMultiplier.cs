using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseJumpHeightMultiplier : MonoBehaviour
{
    //Instantiate the variables
    [SerializeField] private MultiplierHolder _dataHolder;

    /// <summary>
    /// Increase jump height while decreasing speed
    /// </summary>
    /// <param name="collision"></param>
    ///     The collider trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the jump multiplier is less than multiplier, then 
        //    -increase jump height mulitplier
        //    -decrease speed multiplier
        if (_dataHolder.jumpHeightMultiplier < _dataHolder.multiplierRangeMax)
        {

            //Increase jump hiehgt multiplier
            _dataHolder.jumpHeightMultiplier++;

            //Decrease speed multipler
            _dataHolder.speedMultiplier--;


        }
    }
}

