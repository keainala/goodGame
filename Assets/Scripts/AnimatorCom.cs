using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class AnimatorCom : MonoBehaviour
{
    private PlayableGraph playableGraph;
    public AnimationClip attackClip;
    public AnimationClip runClip;
    AnimationPlayableOutput animationPlayableOutput;
    // Start is called before the first frame update
    void Start()
    {
        playableGraph = PlayableGraph.Create();
        animationPlayableOutput = AnimationPlayableOutput.Create(playableGraph, "", GetComponent<Animator>());
        AnimationClipPlayable animationClip1 = AnimationClipPlayable.Create(playableGraph, runClip);
        //playableGraph.Connect(animationClip1,0, animationLayerMixerPlayable, 0);
        //animationLayerMixerPlayable.SetLayerMaskFromAvatarMask(1, bbb);
        animationPlayableOutput.SetSourcePlayable(animationClip1);
        //Debug.Log("fuck");
        playableGraph.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
