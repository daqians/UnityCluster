using UnityEngine;
using System.Collections;
using Leap;

public class MoveFei : MonoBehaviour {
    public GameObject ford;
    public GameObject fingerTip;
    public GameObject myline;
    private HandController hc;
    private Controller leapController;
    //线段渲染器
    private LineRenderer lineRenderer;
    // Use this for initialization
    void Start () {
        hc = GetComponent<HandController>();
        leapController = hc.GetLeapController();
        //hc.GetLeapController().EnableGesture(Gesture.GestureType.TYPECIRCLE);
        //hc.GetLeapController().EnableGesture(Gesture.GestureType.TYPESWIPE);
        //hc.GetLeapController().EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
        if (myline)
        {
            lineRenderer = (LineRenderer)myline.GetComponent("LineRenderer");

            //设置线段长度，这个数值须要和绘制线3D点的数量想等
            //否则会抛异常～～
            lineRenderer.SetVertexCount(2);
        }
        
    }

    Frame currentFrame;
    Frame lastFrame = null;
    Frame thisFrame = null;
    long difference = 0;

    bool isLineStart = false;
    Vector3 lineStart = new Vector3();
    Vector3 lineEnd = new Vector3();

    bool isLeftHandGrabLast = false;
    bool isRightHandGrabLast = false;

    // Update is called once per frame
    void Update () {
        currentFrame = hc.GetFrame();
        //获取钱一帧的frame
        //leapController.Frame(1);

        int leftHandId = -1;
        int rightHandId = -1;
        bool isLeftHandGrab = false;
        bool isRightHandGrab = false;
        int leftIndexFingerId = -1;
        int rightIndexFingerId = -1;
        Vector3 leftIndexFingerV3= new Vector3();
        Vector3 rightIndexFingerV3 = new Vector3();

        //从当前的frame中获取数据
        foreach (var h in currentFrame.Hands)
        {
            if (h.IsRight)
            {
                rightHandId = h.Id;
                isRightHandGrab = DaoTools.isGrab(h);
                foreach (var f in h.Fingers)
                {
                    if (f.Type() == Finger.FingerType.TYPE_INDEX)
                    {
                        rightIndexFingerId = f.Id;
                        rightIndexFingerV3 = DaoTools.leapVectorToUnityVector3(hc,f.TipPosition);
                    }
                }
            }
            else
            {
                leftHandId = h.Id;
                isLeftHandGrab =DaoTools.isGrab(h);
                foreach (var f in h.Fingers)
                {
                    if (f.Type() == Finger.FingerType.TYPE_INDEX)
                    {
                        leftIndexFingerId = f.Id;
                        leftIndexFingerV3 = DaoTools.leapVectorToUnityVector3(hc, f.TipPosition);
                    }
                }
            }
        }

        if (fingerTip)
        {
            fingerTip.transform.position = rightIndexFingerV3;
        }
        

        //定义平移操作，左手不抓，右手抓
        if (!isLeftHandGrab && isRightHandGrab)
        {
            if (lastFrame != null && !isLeftHandGrabLast && isRightHandGrabLast)
            {
                Finger lastRightFinger = lastFrame.Hand(rightHandId).Finger(rightIndexFingerId);
                Vector3 lastRightIndexFingerV3 = DaoTools.leapVectorToUnityVector3(hc, lastRightFinger.TipPosition);
				ford.transform.position = ford.transform.position + rightIndexFingerV3 - lastRightIndexFingerV3;
            }
        }
        //定义缩放和旋转操作，左右手都抓
        else if (isLeftHandGrab && isRightHandGrab)
        {
            if (lastFrame != null && isLeftHandGrabLast && isRightHandGrabLast)
            {
                Finger lastRightFinger = lastFrame.Hand(rightHandId).Finger(rightIndexFingerId);
                Vector3 lastRightIndexFingerV3 = DaoTools.leapVectorToUnityVector3(hc, lastRightFinger.TipPosition);
                Finger lastLeftFinger = lastFrame.Hand(leftHandId).Finger(leftIndexFingerId);
                Vector3 lastLeftIndexFingerV3 = DaoTools.leapVectorToUnityVector3(hc, lastLeftFinger.TipPosition);

                //计算放大缩小的量
                float lastDistance = Vector3.Distance(lastRightIndexFingerV3, lastLeftIndexFingerV3);
                float nowDistance = Vector3.Distance(rightIndexFingerV3, leftIndexFingerV3);
                float scale = 1 + (nowDistance - lastDistance) / lastDistance;
                //Debug.Log("scale:"+scale);
				ford.transform.localScale = new Vector3(
					ford.transform.localScale.x * scale,
					ford.transform.localScale.y * scale,
					ford.transform.localScale.z * scale
                    );

                //计算旋转
                //Debug.DrawLine(leftIndexFingerV3, rightIndexFingerV3, Color.blue);
                //Debug.DrawLine(lastLeftIndexFingerV3, lastRightIndexFingerV3, Color.green);
                Vector3 nowV3Base = rightIndexFingerV3 - leftIndexFingerV3;
                Vector3 lastV3Base = lastRightIndexFingerV3 - lastLeftIndexFingerV3;
                Vector3 scaleV3Now = Vector3.Cross(lastV3Base, nowV3Base)*40;
				ford.transform.Rotate(scaleV3Now, Space.World);
                //Vector3 angle=Vector3.Lerp(
                //    lastRightIndexFingerV3- lastRightIndexFingerV3, 
                //    rightIndexFingerV3- leftIndexFingerV3,
                //    1f
                //    );
                //fei.transform.Rotate(angle);
                //string msg = string.Format("Potation:{0} ", angle);
                //Debug.Log(msg);
            }
        }
        //定义划线开始和进行操作，左手抓右手移动
        else if (isLeftHandGrab && !isRightHandGrab)
        {
            //两只手必须都存在
            if(leftHandId!=-1 && rightHandId != -1 && isLeftHandGrabLast && !isRightHandGrabLast)
            {
                //如果还没开始划线
                if (!isLineStart)
                {
                    lineStart = rightIndexFingerV3;
                    isLineStart = true;
                }
                else
                {
                    lineEnd = rightIndexFingerV3;
                }
            }
        }
        //定义划线结束操作，左手放右手不动
        else
        {
            //两只手必须都存在
            if (leftHandId != -1 && rightHandId != -1 && !isLeftHandGrabLast && !isRightHandGrabLast)
            {
                //如果已经开始划线
                if (isLineStart)
                {
                    lineEnd = rightIndexFingerV3;
                    isLineStart = false;
                }
            }
            //else
            //{
            //    //如果已经开始划线
            //    if (isLineStart)
            //    {
            //        lineEnd = rightIndexFingerV3;
            //        isLineStart = false;
            //    }
            //}
        }
        //if (isLineStart)
        //{
        //    Debug.DrawLine(lineStart, lineEnd, Color.red);
        //}


        //Debug.DrawLine(lineStart, lineEnd, Color.yellow);

        if (lineRenderer)
        {
            Vector3 tempS = lineStart;
            tempS.z -= 5;
            Vector3 tempE = lineEnd;
            tempE.z -= 5;
            lineRenderer.SetPosition(0, tempS);
            lineRenderer.SetPosition(1, tempE);
        }
        

        //if (rightHandId != -1) {
        //    //控制模型方向
        //    Hand h = currentFrame.Hand(rightHandId);
        //    float pitch = h.Direction.Pitch * 180 / Mathf.PI;
        //    float yaw = h.Direction.Yaw * 180 / Mathf.PI;
        //    float roll = h.PalmNormal.Roll * 180 / Mathf.PI;
        //    Debug.Log(pitch + "  " + yaw + "  " + roll);
        //    Quaternion targetRotation = Quaternion.Euler(
        //        -pitch, yaw, roll
        //    );
        //    fei.transform.rotation = targetRotation;
        //}
        lastFrame = currentFrame;
        isLeftHandGrabLast = isLeftHandGrab;
        isRightHandGrabLast = isRightHandGrab;
    }

    void OnGUI()
    {
        /*
        Vector3 tempS = lineStart;
        tempS.z = 0;
        Vector3 tempE = lineEnd;
        tempE.z = 0;
        float d = Vector3.Distance(tempS, tempE);
        GUILayout.Label("tempS：" + tempS);
        GUILayout.Label("tempE：" + tempE);
        GUILayout.Label("测量的距离："+d);
        */
    }
}
