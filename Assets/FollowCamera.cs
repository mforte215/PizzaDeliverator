using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject CarToFollow;
    //Camera Position needs to match Car position

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = CarToFollow.transform.position + new Vector3(0,0,-10);
    }
}
