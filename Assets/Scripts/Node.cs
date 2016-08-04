using UnityEngine;
using System.Collections;

public class NodeAngles
{
    float[] angles;

    public NodeAngles()
    {
        angles = new float[8];

        for(int i = 0, a = 0; i < angles.Length;i++,a += 45)
        {
            angles[i] = a;
            Debug.Log(angles[i]);
        }
    }

    public float ReturnNearestAngle(float angle, int posOrNeg = 0)
    {
        float dif = Mathf.Abs(angles[0] - angle);
        int index = 0;

        for(int i = 1; i < angles.Length; i++)
        {
            float newDif = Mathf.Abs(angles[i] - angle);
            if (newDif < dif)
            {
                dif = newDif;
                index = i;
            }
        }

        index += posOrNeg;

        if (index == angles.Length)
            index = 0;
        else if (index == -1)
            index = angles.Length - 1;

        return angles[index];
    }
}


public class Node : MonoBehaviour {

    public static NodeAngles nodeAngles = null;

    // Use this for initialization
    void Awake() {
        if (nodeAngles == null) {
            nodeAngles = new NodeAngles();
        }
	}
}
