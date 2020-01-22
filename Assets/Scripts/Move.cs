using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public enum PlayerState
{
    Idle,
    Run,
    Jump
}
public class Move : MonoBehaviour
{
    public Fire gun;
    public AnimationClip aaa;
    public AvatarMask bbb;
    public float speed = 12.0F;
    public float jumpSpeed = 10.0F;
    public float gravity =20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float down = 0;
    private float jumpCd=2f;
    private PlayableGraph playableGraph;
    AnimationClip jumpClip;
    AnimationClip runClip;
    AnimationClip idleClip;
    AnimationPlayableOutput animationPlayableOutput;
    PlayerState curState = PlayerState.Idle;
    PlayerState lastState = PlayerState.Idle;
    private Vector3 OriginPos;
    private bool isEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        OriginPos = transform.position;
        OriginPos.y = OriginPos.y + 0.1f;
        playableGraph = PlayableGraph.Create();
        animationPlayableOutput = AnimationPlayableOutput.Create(playableGraph, "", GetComponent<Animator>());
        //AnimationLayerMixerPlayable animationLayerMixerPlayable = AnimationLayerMixerPlayable.Create(playableGraph, 3);
        ///animationPlayableOutput.SetSourcePlayable(animationLayerMixerPlayable);
        jumpClip =  Resources.Load("Jump") as AnimationClip;
        runClip = Resources.Load("Run") as AnimationClip;
        idleClip = Resources.Load("Idle") as AnimationClip;
        //AnimationClip[] animationClip = Resources.LoadAll<AnimationClip>("BasicMotions@Jump01");


    }

    private void PlayAnimation()
    {
        AnimationClip cur= idleClip;
        switch (curState)
        {
            case PlayerState.Idle:
                {
                    cur = idleClip;
                }
                break;
            case PlayerState.Jump:
                {
                    cur = jumpClip;
                }
                break;
            case PlayerState.Run:
                {
                    cur = runClip;
                }
                break;
        }
        AnimationClipPlayable animationClip1 = AnimationClipPlayable.Create(playableGraph, cur);
        //playableGraph.Connect(animationClip1,0, animationLayerMixerPlayable, 0);
        //animationLayerMixerPlayable.SetLayerMaskFromAvatarMask(1, bbb);
        animationPlayableOutput.SetSourcePlayable(animationClip1);
        //Debug.Log("fuck");
        playableGraph.Play();
    }
    private GameObject M_target;
    private List<GameObject> m_targets= new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            if (M_target == null)
            {
                M_target = other.gameObject;
                transform.LookAt(M_target.transform);
            }
            else
            {
                m_targets.Add(other.gameObject);
            }
        }
        if (other.tag == "GameEnd")
        {
            isEnd = true;
            StopAllCoroutines();
            StartCoroutine(End());
        }
    }
    public IEnumerator End()
    {
        yield return new WaitForSeconds(0.1f);
        isEnd = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            moveDirection = Vector3.zero;
            transform.position = OriginPos;
            down = 0;
            //
            return;
        } 
        CharacterController controller = GetComponent<CharacterController>();
        float mx = Input.GetAxis("Horizontal");
        float my = Input.GetAxis("Vertical");
        if (curState == lastState) { }
        else
        {
            lastState = curState;
            PlayAnimation();
        }
        if (controller.isGrounded && curState == PlayerState.Jump) { curState = PlayerState.Idle; }
     // { jumpCd = 2; }
        {
            moveDirection = new Vector3(mx, down, 0);
            //moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = new Vector3(moveDirection.x * speed, moveDirection.y, 0);// moveDirection.z*speed);// speed;
                                                                                                           // if (jumpCd > 0)
            {
                //if (Input.GetButtonDown("Jump"))
                if (controller.isGrounded)
                {
                    jumpCd = 2;
                    //curState = PlayerState.Jump;
                    //AnimationClipPlayable animationClip1 = AnimationClipPlayable.Create(playableGraph, jumpClip);
                    ////playableGraph.Connect(animationClip1,0, animationLayerMixerPlayable, 0);
                    ////animationLayerMixerPlayable.SetLayerMaskFromAvatarMask(1, bbb);
                    //animationPlayableOutput.SetSourcePlayable(animationClip1);
                    //moveDirection.y = jumpSpeed;
                    //jumpCd--;
                }
                else
                { moveDirection.y -= gravity * Time.deltaTime; }
                if (Input.GetButtonDown("Jump") && jumpCd>0)
                {
                    jumpCd--;
                    moveDirection.y = jumpSpeed;
                    curState = PlayerState.Jump;
                }
            }
        }
        if (controller.isGrounded)
        {
            if (mx != 0)

            {
                curState = PlayerState.Run;
            }
            else
            {
                curState = PlayerState.Idle;
            }

        }
        //transform.Rotate(Vector3.up, mx*2);

        //
        down = moveDirection.y;// - 1 * gravity * Time.deltaTime;
                               //Debug.Log(moveDirection);
                               // moveDirection= transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(new Vector3(mx, 0, 0));
   


        // CharacterController controller = GetComponent<CharacterController>();
        // float mx = Input.GetAxis("Horizontal");
        // float my = Input.GetAxis("Vertical");
        // if (curState == lastState) { }
        // else
        // {
        //     lastState = curState;
        //     PlayAnimation();
        // }
        // if (controller.isGrounded && curState == PlayerState.Jump) { curState = PlayerState.Idle; }
        // if (controller.isGrounded) { jumpCd = 2; }
        // {
        //     moveDirection = new Vector3(mx, down, my);
        //     //moveDirection = transform.TransformDirection(moveDirection);
        //     moveDirection = new Vector3(moveDirection.x * speed, moveDirection.y, moveDirection.z * speed);// moveDirection.z*speed);// speed;
        //     if (jumpCd > 0)
        //     {
        //         if (Input.GetButtonDown("Jump"))
        //         {
        //             curState = PlayerState.Jump;
        //             //AnimationClipPlayable animationClip1 = AnimationClipPlayable.Create(playableGraph, jumpClip);
        //             ////playableGraph.Connect(animationClip1,0, animationLayerMixerPlayable, 0);
        //             ////animationLayerMixerPlayable.SetLayerMaskFromAvatarMask(1, bbb);
        //             //animationPlayableOutput.SetSourcePlayable(animationClip1);
        //             moveDirection.y = jumpSpeed;
        //             jumpCd--;
        //         }
        //     }
        // }

        // //transform.Rotate(Vector3.up, mx*2);

        // moveDirection.y -= gravity * Time.deltaTime;//
        // down = moveDirection.y;// - 1 * gravity * Time.deltaTime;
        //                        //Debug.Log(moveDirection);
        //// moveDirection= transform.TransformDirection(moveDirection);
        // controller.Move(moveDirection * Time.deltaTime);
        // if (mx == 0 && my == 0)
        // {
        //     if (curState == PlayerState.Idle || curState == PlayerState.Run)
        //     {
        //     //AnimationClipPlayable animationClip1 = AnimationClipPlayable.Create(playableGraph,idleClip);
        //     ////playableGraph.Connect(animationClip1,0, animationLayerMixerPlayable, 0);
        //     ////animationLayerMixerPlayable.SetLayerMaskFromAvatarMask(1, bbb);
        //     //animationPlayableOutput.SetSourcePlayable(animationClip1);
        //     ////Debug.Log("fuck");
        //     //playableGraph.Play();
        //         curState = PlayerState.Idle;
        //     }
        //     return;
        // }
        // else
        // {
        //     if (controller.isGrounded && curState== PlayerState.Idle)
        //     {
        //         curState = PlayerState.Run;
        //     }

        // }
        // if (!gun.isFire)
        // {
        //     transform.rotation = Quaternion.LookRotation(new Vector3(mx, 0, my));
        // }

    }

}
