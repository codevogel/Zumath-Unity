﻿using Assets.Scripts.Dataset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Checkpoint
{
    class CheckpointHandler : MonoBehaviour
    {
        private void Awake()
        {
            CheckpointManager.Awake();
        }

    }
}
