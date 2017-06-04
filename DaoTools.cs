using UnityEngine;
using System.Collections;
using Leap;

public class DaoTools{
    //获取手是否有抓的动作
    public static bool isGrabOld(Hand h) {
        float strength = h.GrabStrength;
        //Debug.Log("strength:" + strength);
        if (strength > 0.4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //获取手是否有抓的动作
    public static bool isGrab(Hand h)
    {
        Vector3 indexFingerV3=new Vector3();
        Vector3 thumbFingerV3 = new Vector3();
        
        foreach (var f in h.Fingers)
        {
            if (f.Type() == Finger.FingerType.TYPE_INDEX)
            {
                indexFingerV3 = f.TipPosition.ToUnityScaled(false);
            }
            else if (f.Type() == Finger.FingerType.TYPE_THUMB)
            {
                thumbFingerV3 = f.TipPosition.ToUnityScaled(false);
            }
        }
        float dis = Vector3.Distance(indexFingerV3, thumbFingerV3);
        //Debug.Log("distance:" + dis);
        if (dis < 0.04f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //将Leap Motion中获取到的坐标信息转化为Unity的世界坐标
    public static Vector3 leapVectorToUnityVector3(HandController hc, Leap.Vector leapVector)
    {
        Vector3 unityPosition_now = leapVector.ToUnityScaled(false);
        Vector3 worldPosition_now = hc.transform.TransformPoint(unityPosition_now);
        return worldPosition_now;
    }
}
