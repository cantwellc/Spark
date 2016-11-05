using UnityEngine;
using System.Collections;

public class FollowCharacter : MonoBehaviour {
    private Transform _character;
    private bool _follow;

	public void StartFollowing()
    {
        _character = Character.current.transform;
        _follow = true;
    }

    public void StopFollowing()
    {
        _follow = false;
    }

    void Update()
    {
        if (!_follow) return;

    }
}
