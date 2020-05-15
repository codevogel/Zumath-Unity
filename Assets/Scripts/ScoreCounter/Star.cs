using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;


public class Star : MonoBehaviour
{
    public bool zeroStarEnabled = false;
    public bool oneStarEnabled = false;
    public bool twoStarEnabled = false;
    public bool threeStarEnabled = false;

    public Image starOne, starTwo, starThree;

    public static void Start()
    {
        GameObject.Find("StarSprite");
        starOne.enabled = false;
        starTwo.enabled = false;
        starThree.enabled = false;
    }
}
    public class ChildStarOne : Star
    {
        public void StarOne()
        {
        }
    }
    public class ChildStarTwo : Star
    {
        public void StarTwo()
        {
        }
    }
    

    public class ChildStarThree : Star
    {
        public void StarThree()
        {
        }
    }
    


