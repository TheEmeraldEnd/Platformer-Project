using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    #region external variable declarations
    //player variables
    [Tooltip("The player tag of the player game object")]
    [SerializeField] private string _playerTag = "Player";

    [Tooltip("The player game object")]
    private GameObject _player;

    [Tooltip("The locomotion script of the player")]
    private Locomotion _playerLocomotionScript;

    //Multiplier holder
    [Tooltip("The data holder for the movement")]
    [SerializeField] private MultiplierHolder _dataHolder;
    #endregion

    #region internal variables
    #endregion

    /// <summary>
    /// Instantiate the external variables
    /// </summary>
    void Awake()
    {
        //Instantiate the player variables
        _player = GameObject.FindGameObjectWithTag(_playerTag);

        _playerLocomotionScript = _player.GetComponent<Locomotion>();

        //Reset the multipliers per scene
        _dataHolder.speedMultiplier = 0;
        _dataHolder.jumpHeightMultiplier = 0;
    }

    /// <summary>
    /// Every update
    /// </summary>
    void Update()
    {
        #region player movement
        //Update player movement
        _playerLocomotionScript.UpdateMovement();

        //Update the player movement movement variables
        _playerLocomotionScript.CalculateNewJumpHeight(_dataHolder.baseJumpHeight,
            _dataHolder.jumpHeightSD, _dataHolder.jumpHeightMultiplier);

        _playerLocomotionScript.CalculateNewSpeed(_dataHolder.baseSpeed,
            _dataHolder.speedSD, _dataHolder.speedMultiplier);
        #endregion
    }
}
