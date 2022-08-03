using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InverseKinematics
{
    public class JointController : MonoBehaviour
    {
        private GameObject[] joint = new GameObject[2];
        private GameObject[] arm = new GameObject[2];
        private Vector3[] angle = new Vector3[2];

        private GameObject[] slider = new GameObject[2];
        private float[] sliderVal = new float[2];
        // Start is called before the first frame update
        void Start()
        {
            for(int i=0;i<joint.Length; i++){
                joint[i] = GameObject.Find("joint_"+i.ToString());
                arm[i] = GameObject.Find("arm_"+i.ToString());
            }

            for(int i=0;i<joint.Length; i++){
                slider[i] = GameObject.Find("slider_"+i.ToString());
                sliderVal[i] = slider[i].GetComponent<Slider>().value;
            }
        }

        // Update is called once per frame
        void Update()
        {
            for(int i=0;i<joint.Length;i++) {
                sliderVal[i] = slider[i].GetComponent<Slider>().value;
                angle[i].z = sliderVal[i];
                joint[i].transform.localEulerAngles = angle[i];
            }
        }
    }
}