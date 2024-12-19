# My-First-Person-FPS

## 项目展示
视频地址：https://www.bilibili.com/video/BV1L1k6YXEhX

## 项目要求

- **游戏场景**（14分）
  -  地形（2分）：使用**地形组件**，上面有**山、路、草、树**；（可使用第三方资源改造）
  -  天空盒（2分）：使用**天空盒**，天空可随 玩家位置 或 时间变化 或 按特定按键**切换天空盒**；
  -  固定靶（2分）：使用**静态物体**，有一个以上固定的靶标；（注：射中后状态不会变化）
  -  运动靶（2分）：使用**动画运动**，有一个以上运动靶标，运动轨迹，速度使用动画控制；（注：射中后需要有效果或自然落下）
  -  射击位（2分）：地图上应标记若干射击位，仅在射击位附近或区域可以拉弓射击，每个位置有 n 次机会；
  -  摄像机（2分）：使用**多摄像机**，制作 鸟瞰图 或 瞄准镜图 使得游戏更加易于操控；
  -  声音（2分）：使用**声音组件**，播放背景音 与 箭射出的声效；
- **运动与物理与动画**（8分）
  -  游走（2分）：使用**第一人称组件**，玩家的驽弓可在地图上游走，不能碰上树和靶标等障碍；（注：建议使用 [unity 官方案例](https://assetstore.unity.com/packages/essentials/starter-assets-firstperson-updates-in-new-charactercontroller-pa-196525)）
  -  射击效果（2分）：使用 **物理引擎** 或 **动画** 或 **粒子**，运动靶被射中后产生适当效果。
  -  碰撞与计分（2分）：使用 **计分类** 管理规则，在射击位射中靶标得相应分数，规则自定；（注：应具有现场修改游戏规则能力）
  -  驽弓动画（2分）：使用 **动画机** 与 **动画融合**, 实现十字驽蓄力**半拉弓**，然后 **hold**，择机 **shoot**；
- **游戏与创新**（不限项，每项 2 分）
  -  场景与道具类: 有趣的事物 或 模型等 （可以模仿 Unity 官方案例，在地形基础上搭建几何型场地）
  -  效果类：如显示箭的轨迹，特殊声效，等
  -  力场类: 如运用力场实现 ai 导航 与 捕获等
  -  玩法类:
  -  游戏感: 这是一个模糊的指标，有游戏感也许是某些人的天赋。



## 具体要求实现

### 地形

采用 Unity 的 **Terrain 组件**实现，具体可从从 [Unity 资源商店](https://assetstore.unity.com/zh-CN) 寻找自己喜欢的 Terrain 资源，具体有以下两种方法：

- 资源包内自带完整的地形场景，直接将预制件拖入场景之中即可（笔者采用的资源：[built-in 地形](https://www.bilibili.com/video/BV1Yx4y1s7dM)）
- 资源包只给出了一些花草树木土地的资源，可以采用 Unity 的**笔刷**功能进行个性化绘制

<img src="imgs/1.png" style="zoom:50%;" />

> [!NOTE]
>
> 下载资源时注意渲染管线的区别（内置渲染管线（built-in）、通用渲染管线（URP）、高清渲染管线（HDRP））

### 天空盒

天空盒的设置比较简单，在 Window > Rendering > Lighting，在 Environment 标签中找到 Skybox Material，在其中设置需要的天空盒，同样我们可以从 [Unity 资源商店](https://assetstore.unity.com/zh-CN) 寻找所需资源，笔者采用的天空盒资源为 [Skybox Series Free](https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-series-free-103633)，

<img src="imgs/2.png" style="zoom:50%;" />

天空盒的切换也比较简单，可以采用以下方法：

- 特定按键触发
- 随时间切换，笔者将游戏中一天的时间长度设置为 $240s$，**按照时间顺序，循环播放日出、白天、日落、夜晚四个天空盒**

### 固定靶

固定靶采用**圆柱体+纹理材质**制作，随机放置在场景之中，通过与弓箭的碰撞检测来调用 GameManager 中的 Score Manager 实现分数的增加

![](imgs/3.png)

> [!NOTE]
>
> 因为没有找到其他比较好的资源，于是就自行制作了

### 运动靶

运动靶和固定靶相比，其实就只是增加了动画部分。可以在 **Window > Animation** 中找到相关部分，具体来说分为以下两步：

- 使用 Animation 制作动画
- 使用 Animator 来控制动画的转化过程

<img src="imgs/4.png" style="zoom:50%;" />

<img src="imgs/5.png" style="zoom:50%;" />

> [!NOTE]
>
> 可以简单的用平移来表示运动过程；用旋转来模拟靶倒下的情况，旋转部分为采用动画实现，而是对 transform 进行插值实现

### 射击位

因为仅在射击位才能进行射击，这里为了简便起见，采用 Panel + Mesh Collider 进行设置。当玩家未进入射击位时，只需要设置将子弹数量设为 $0$；当玩家进入射击位时，只需要增加子弹数量即可

<img src="imgs/14.png" style="zoom:50%;" />


### 摄像机

由于要求要使用多摄像机，制作鸟瞰图或者瞄准镜图，本项目使用了三个摄像机：

- 主摄像机用于观察除武器外的所有场景

<img src="imgs/6.png" style="zoom:50%;" />

- 武器摄像机只用于观察武器

![](imgs/7.png)

- 鸟瞰摄像机用于跟随玩家，给出鸟瞰图

<img src="imgs/8.png" style="zoom:50%;" />

制作以上摄像机后，就可以考虑如何将画面插入游戏背景之中，具体来说分为以下三步：

- 创建一个 `Assets->Create->RenderTexture` 作为小地图的输出，这里可以设置你想要的分款率等信息，然后将需要的现实的 Camera 挂载即可
- 在 UI 中创建一个 Image 或者 RawImage 作为上述 RenderTexture 的载体即可
- 设置 Image 或者 RawImage 的边框，大小等，以及为 Canvas 添加 Canvas Scalar 组件并设置为 `Scale With Screen Size` 以适应游戏背景大小变化的情况

<img src="imgs/19.png" style="zoom:50%;" />

### 声音

Unity 的声音组件 Audio Source 和 Audio Clip 其实比较简单，只需要简单地将音频拖入属性中，然后进行在脚本内简单的调用即可。一般来说，游戏背景音效放在整个游戏的 GameManager 内，单独的音效放在各自所需要的地方即可

![](imgs/9.png)

![](imgs/20.png)


### 游走

关于第一人称组件，[Unity 资源商店](https://assetstore.unity.com/zh-CN) 有许多，比如说官方推荐的 [第一人称角色控制器](https://assetstore.unity.com/packages/essentials/starter-assets-thirdperson-updates-in-new-charactercontroller-pa-196526)，或者 Unity 自带的 FPS Microgame 模板，都是一个不错的选择，当然也可以自行编写脚本🤔

![](imgs/10.png)

> [!NOTE]
>
> 这些脚本一般都提供了 `shift` —— 加速，`wasd` 移动，`空格` —— 跳跃，`c` —— 蹲下等操作



### 射击效果

射击效果这里直接采用上述提到的Unity 自带的 [FPS Microgame 模板](https://assetstore.unity.com/packages/tools/input-management/mini-first-person-controller-174710)，可以直接使用里面的粒子效果；同时，也可以设置与敌人碰撞后的粒子效果

<img src="imgs/11.png" style="zoom: 50%;" />

### 碰撞与计分

项目采用 Game Manager 来管理，其中的 Score Manager 用作计分类来管理游戏得分，每当目标靶被击中时，则增加相应得分，同时，将分数属性作为 Public，方便在项目中直接进行更改

### 弩弓动画

[十字弩](https://assetstore.unity.com/packages/3d/props/weapons/classical-crossbow-196127)资源已经为我们准备好了相应的动画，用 Fire 表示拉弓和松开，用 Hold 表示不变。因此，对于我们来说，只需要进行相关的动画状态变化即可

<img src="imgs/12.png" style="zoom:50%;" />

> [!NOTE]
>
> 由于资源现有的动画其实对于我们的需求来说可以省略一些情况，我们只需要在蓄力（`Fill = true`）的情况下，进入 `Fill` 状态，同时设置 `animator.speed` 来控制动画，比如说通过设置 `animator.speed = 0` 来暂停动画，从而实现半拉弓的状态；最后通过设置 `Fire = true` 的条件，进入 `Shoot` 状态进行射击
>
> 但是由于 `Shoot` 状态箭的起始位置其实并不是 `Fill` 状态的结束的位置，因此仍然有所偏差；应该使用一些变量来控制动画的一些位置等，但是不太会😮‍💨


## 创新

### 解决穿模问题

使用 Unity 官方提供的第一人称角色控制器时，可能会存在武器穿模的问题，而这实际上也是 FPS 游戏中经常会遇到的问题。有两种经典的解决方法：

- 对武器使用碰撞体和刚体，这样就不会导致穿模问题的发生
- 采用双摄像机，也即上述摄像机部分，利用 PS 图层的概念，对摄像机也可以设置不同的深度和可观测的层，以达到类似 PS 图层的概念，即武器的层始终在其它场景之上

<img src="imgs/13.png" style="zoom:50%;" />

### UI 界面

使用 Canvas 进行绘制得分、血量、弹夹容量，弹夹容量随子弹数量不断变化

<img src="imgs/15.png" style="zoom:50%;" />

### 十字准星

设置十字准心，正常时候为绿色 + 大尺寸准心，当瞄准敌人时为红色 + 较小尺寸，尽可能模拟 FPS 游戏

![](imgs/17.png)

### 较好的项目结构

将项目基本分为 Game Manager、Player、Environment、Enemy 几部分，同时，将其作为预制件储存，有利于重复使用

![](imgs/16.png)

### 简单的换枪实现

玩家可以在开始的时候选择多把武器，在游戏中进行切换，数字键或者 Q

![](imgs/18.png)