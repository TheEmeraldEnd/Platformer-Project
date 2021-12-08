using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MultiplierHolder")]
public class MultiplierHolder : ScriptableObject
{
    #region both components
    [Header("Both components")]

    [Tooltip("The max and min a multiplier can be")]
    [SerializeField] public int multiplierRangeMax;
    #endregion

    #region horizontal components
    [Header("Horizontal Components")]

    [Tooltip("The base speed of the player in meters per second")]
    [SerializeField] public float baseSpeed;

    [Tooltip("The multiplier of the speed")]
    [SerializeField] public int speedMultiplier;

    [Tooltip("The standard deviation the speed can be in meters per second")]
    [SerializeField] public float speedSD;
    #endregion

    #region vertical components
    [Header("Vertical Components")]

    [Tooltip("The base jump height in meters")]
    [SerializeField] public float baseJumpHeight;

    [Tooltip("The jump height multiplier in meters")]
    [SerializeField] public int jumpHeightMultiplier;

    [Tooltip("The standard deviation of the jump height in meters")]
    [SerializeField] public float jumpHeightSD;
    #endregion
}
