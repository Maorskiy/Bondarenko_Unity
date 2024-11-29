using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Sources.Client.Runtime.Activities.Game.Commands
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform doodlePos;

        void Update()
        {
            if (doodlePos.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, doodlePos.position.y, transform.position.z);
            }
        }
    }

}
