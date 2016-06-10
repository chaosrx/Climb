using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Locomotion,
    Jump,
    Fall
}

public class PlayerFSM : FSMBase 
{
    private Player player;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
    }

    private void Locomotion()
    {
        Vector3 newDir = transform.forward * input.joyStickDirection.y + transform.right * input.joyStickDirection.x;
        player.SetDirection(newDir);
        if (Input.GetButton("Fire1"))
            player.RotateHeadDirection();

        player.Move();
    }

    #region Locomotion

    private IEnumerator LocomotionEnterState()
    {
        yield break;
    }
    private void LocomotionManualUpdate()
    {
        if (input.IsKeyDown(InputType.B))
        {
            state = PlayerState.Jump;
            return;
        }

        Locomotion();
    }
    private IEnumerator LocomotionExitState()
    {
        yield break;
    }

    #endregion

    #region Jump

    private Vector3 savePos;

    private bool IsFall()
    {
        if (transform.position.y < savePos.y)
            return true;
        return false;
    }

    private IEnumerator JumpEnterState()
    {
        yield break;
    }
    private void JumpManualUpdate()
    {
        if (IsFall())
        {
            state = PlayerState.Fall;
            return;
        }
        if (!player.Jumping)
            player.Jump();

        savePos = transform.position;
        Locomotion();
    }
    private IEnumerator JumpExitState()
    {
        savePos = Vector3.zero;
        yield break;
    }

    #endregion

    #region Fall

    private float landCheckEpsilon = 1.1f;

    private bool IsLand()
    {
        Ray bottomRay = new Ray(transform.position , Vector3.down);
        RaycastHit hitInfo = new RaycastHit();

        if (Physics.Raycast(bottomRay, out hitInfo, float.MaxValue, Tags.LandMask))
        {
            Debug.DrawRay(bottomRay.origin, bottomRay.direction, Color.red, 0.1f);
            float distance = Vector3.Distance(hitInfo.point, transform.position);
            if (distance < landCheckEpsilon)
                return true;
        }

        return false;
    }

    private IEnumerator FallEnterState()
    {
        yield break;
    }
    private void FallManualUpdate()
    {
        if (IsLand())
        {
            player.Landing();
            state = PlayerState.Locomotion;
            return;
        }
        savePos = transform.position;

        Locomotion();
    }
    private IEnumerator FallExitState()
    {
        yield break;
    }

    #endregion


}
