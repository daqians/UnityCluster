# UnityCluster

This project was developed by Unity and Leap Motion to realize the interaction between multiscreens and users. This multiscreen displaying system using Network and software connect screens to achieve parellal displaying in multiscreens. Gestures and voice and be used to munipulate to model in screen via Leap Motion (Gestures dector) or HoloLens (AR head wear glass). 3D model view can be displayed via 4K screens and AR display hardware like smartphone and HoloLens.

Hardware is combined by WIFI network,five 4K screens,an android smartphone,Leap Motion and 5 CPUs.

'Cluster Package' is the main component in this project.

I have also added some other fuctions to elevate the effect of display.Like AR modle display in Android phone and Leap Motion.

## Picture view

![image](http://img.blog.csdn.net/20170604194742318?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvanhzZHE=/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

![image2](http://img.blog.csdn.net/20170604204835240?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvanhzZHE=/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

![image3](http://img.blog.csdn.net/20170604204847036?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvanhzZHE=/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

![image4](http://img.blog.csdn.net/20170604204817036?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvanhzZHE=/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

## Document description

- **Daotools.cs: The detector of different actions on the model**

- **Flycamera.cs: The controlor of moving the camera position and perspective**

- **MoveFei.cs: The controlor of moving,zooming in and out and rotating the model**

- **InstantiateNode.cs: Initializing the different node and identify the node attitude with different position**

- **NodeInformation.cs: The file which stored the information of node, this will be detected by InstantiateNode**

