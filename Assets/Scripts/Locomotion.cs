using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Locomotion : MonoBehaviour
{
    #region Variable Declarations
    //Both horizontal and vertical components
    [Tooltip("The rigid body of the player")]
    [SerializeField] private Rigidbody2D _playerRigidBody;

    [Tooltip("Player collider")]
    [SerializeField] private Collider2D _playerCollider;

    [Tooltip("Masks that count as ground")]
    [SerializeField] private LayerMask _groundMask;

    //Horizontal components
    [Tooltip("The horizontal speed of the player in meters per second")]
    [SerializeField] private float _speed;

    //Vertical Components
    [Tooltip("The acceleration of the player downward")]
    [SerializeField] private float _gravity;

    [Tooltip("The max jump height in meters")]
    [SerializeField] private float _jumpHeight;

    [Tooltip("Checks if the jump cancel has been used or not")]
    [SerializeField] private bool _isJumpCancelled;

    #endregion

    /// <summary>
    /// Instantiate the variables
    /// </summary>
    private void Awake()
    {
        //Instantiate the player movable component
        _playerRigidBody = this.GetComponent<Rigidbody2D>();

        //INstantiate the player collider
        _playerCollider = this.GetComponent<Collider2D>();
    }

    /// <summary>
    /// Update the movement of the player
    /// </summary>
    public void UpdateMovement()
    {
        #region horizontal movement
        //Calculate the velocity in meters per second
        float xVelocity = Input.GetAxis("Horizontal") * _speed;
        #endregion

        #region Vertical movement
        //Calculate the vertical velocity in meters per second
        float yVelocity = _playerRigidBody.velocity.y;

        //Add in appropriate gravity responses
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            yVelocity += Mathf.Sqrt(2f * _gravity * _jumpHeight);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && _isJumpCancelled == false)
        {
            yVelocity = 0f;

            _isJumpCancelled = true;
        }

        if (IsGrounded())
        {
            _isJumpCancelled = false;
        }
        #endregion

        //Apply the velocity
        _playerRigidBody.velocity = new Vector2(xVelocity, yVelocity);
    }

    #region calculation methods

    /// <summary>
    /// Update the jump height based on the multiplier
    /// </summary>
    /// <param name="baseJumpHeight"></param>
    ///     The base jump height in meters
    /// <param name="jumpHeightSD"></param>
    ///     The jump height standard variation in meters
    /// <param name="jumpHeightMultiplier"></param>
    ///     The multiplier for jump height
    public void CalculateNewJumpHeight(float baseJumpHeight, float jumpHeightSD,
        int jumpHeightMultiplier)
    {
        //Update jump height
        _jumpHeight = baseJumpHeight + jumpHeightSD * (float)jumpHeightMultiplier;
    }

    /// <summary>
    /// Calculate the speed of the player in meters per second
    /// </summary>
    /// <param name="baseSpeed"></param>
    ///     The base speed in meters per second
    /// <param name="speedSD"></param>
    ///     The standard deviation of the speed in meters per second
    /// <param name="speedMultiplier"></param>
    ///     The multiplier of the speed
    public void CalculateNewSpeed(float baseSpeed, float speedSD, int speedMultiplier)
    {
        //Update speed
        _speed = baseSpeed + speedSD * (float)speedMultiplier;
    }
    #endregion

    #region checks
    /// <summary>
    /// Finds out if the player is grounded
    /// </summary>
    /// <returns></returns>
    ///     Returns if the player is grounded or not
    private bool IsGrounded()
    {
        //Check if the player is grounded or not
        bool groundHit = _playerCollider.IsTouchingLayers(_groundMask);

        //Return the result
        return groundHit;
    }
    #endregion
}
