using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseVelocityTrigger : MonoBehaviour
{
    //Instantiate the variables
    [SerializeField] private MultiplierHolder _dataHolder;

    /// <summary>
    /// Increase velocity while decreasing jump height
    /// </summary>
    /// <param name="collision"></param>
    ///     The collider trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the speed multiplier is less than multiplier, then 
        //    -increase speed mulitplier
        //    -decrease jump height multiplier
        if (_dataHolder.speedMultiplier < _dataHolder.multiplierRangeMax)
        {

            //Increase speed multiplier
            _dataHolder.speedMultiplier++;

            //Decrease jump height multipler
            _dataHolder.jumpHeightMultiplier--;


        }
    }

}
