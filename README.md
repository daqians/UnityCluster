# UnityCluster

This project was developed by Unity to realize the interaction between multi screens and users. This multiscreen displaying system using Network and software connect screens to achieve parallel displaying in multi-screens. Gestures and voice and be used to manipulate to model in screen via wearable devices like HoloLens (AR headwear glass) and Leap Motion (Gestures detector). The 3D model view can be displayed via 4K screens and AR display hardware like smartphones and HoloLens.

The project mainly solve the problem that model demonstrations in large conference rooms with wearable devices. The presenter implement the model conveniently via wearable devices (in this project we use HoloLens and Leap Motion). And the audience can observe the model using large multi screens or their smart phones.

Hardware is combined with HoloLens, five 4K screens, an Android smartphone, Leap Motion and 5 CPUs.

Some other functions have also been added to elevate the effect of display. Like AR model display function in Android phone and Leap Motion.

## Picture view
These diagrams present the view on parallel display screens. The views in HoloLens can not upload in git.
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

