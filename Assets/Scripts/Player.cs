using UnityEngine;
using System.Collections;

public class Player : JumperBehavior
{
    public float speed = 3.0f;
    public float jumpPower = 5000.0f;
    public Vector3 direction { private set; get; }
    public Rigidbody jumperRigidBody { private set; get; }
    public CapsuleCollider jumperCollider { private set; get; }
    public PlayerFSM fsm { private set; get; }
    public bool Jumping = false;

    protected override void Awake()
    {
        base.Awake();
        jumperRigidBody = GetComponent<Rigidbody>();
        jumperCollider = GetComponent<CapsuleCollider>();
        fsm = GetComponent<PlayerFSM>();
    }

    private void Start()
    {
        fsm.state = PlayerState.Locomotion;
        game.scene.SetPlayer(this);
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    public void MakeDirection(Vector3 target)
    {
        direction = (target - transform.position).normalized;
    }

    public void Move()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    public void RotateHeadDirection()
    {
        transform.forward = new Vector3(game.ovrCamRig.centerEyeAnchor.transform.forward.x, transform.forward.y, game.ovrCamRig.centerEyeAnchor.transform.forward.z);
    }

    public void Jump()
    {
        Jumping = true;
        jumperRigidBody.AddForce((Vector3.up + direction) * jumpPower);
    }

    public void Landing()
    {
        Jumping = false;
    }

    public override void ManualUpdate()
    {
        fsm.ManualUpdate();
    }
}
