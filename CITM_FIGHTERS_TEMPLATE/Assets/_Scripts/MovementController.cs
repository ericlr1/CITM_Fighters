using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    Vector2 MoveLimits=new Vector2(-5,5);

    [SerializeField]
    float SafetyDistance=0.5f;
    // Start is called before the first frame update
   

    private Animator _animator;
    private Transform _otherPlayer;

    public static int _playercount;
    int _id;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _id = _playercount++;
    }

    public void SetOtherPlayer(Transform other)
    {
        _otherPlayer = other;
    }

    
    public void TryMove(float speed)
    {

        if (CanMove(speed) && speed != 0f)
        {
            float directionSpeed = _id == 1 ? -speed : speed;

            _animator.SetInteger(PlayerController.SPEED, speed > 0f ? 1 : -1);

            float deltaSpeed = directionSpeed * Time.deltaTime;

            Vector3 pos = transform.position;
            pos.x += deltaSpeed;
            transform.position = pos;
        }
        else
        {
            _animator.SetInteger(PlayerController.SPEED, 0);
        }
    }

    public void LateUpdate()
    {
        var pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }

    bool CanMove(float speed)
    {
        if (speed < 0)
            return CanMoveLeft();
        if (speed > 0)
            return CanMoveRight();

        return true;
    }

    bool CanMoveLeft()
    {
        if (transform.position.x <= MoveLimits.x)
            return false;

        if (_otherPlayer == null)
            return true;

        if (_id == 1 && transform.position.x <= (_otherPlayer.position.x + SafetyDistance))
            return false;

        return true;
    }
    bool CanMoveRight()
    {
        if (transform.position.x >= MoveLimits.y)
            return false;

        if (_otherPlayer == null)
            return true;

        if (_id == 0 && transform.position.x >= (_otherPlayer.position.x - SafetyDistance))
            return false;

        return true;
    }

  
}
