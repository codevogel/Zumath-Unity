using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using References;

namespace AnimationManagers
{
    public class ScreenShake : MonoBehaviour
    {
        public Animator camAnim;

        private void Awake()
        {
            gameObject.tag = Tags.SCREENSHAKE;
        }

        // Triggers the screenshake animation.
        public void CamShake()
        {
            camAnim.SetTrigger("ScreenShake");
        }
    }
}