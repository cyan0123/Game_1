# 游戏策划书
## 1 游戏概述
### 1.1 游戏背景
&emsp;&emsp;一名中医药专业学生在复习时意外睡着，穿越回东汉末年成为张仲景。但他在穿越后不小心将桌子上一张手稿意外烧毁，经他确认，正是《伤寒杂病论》中所记载的一张药方，但他的记忆中遗漏了该药方的几味药材。为了保持这份瑰宝的完整性、防止这份药方消散于历史长河中，他决定依靠自己的力量补全这份药方 $\cdots$   
### 1.2 游戏类型及流程简介
&emsp;&emsp;本游戏为一款第三人称视角的3D角色扮演游戏，主要目的是为了科普中医药相关知识，玩家需操控游戏角色**采集草药**、**配置药方**、**以身试药**直至确定完整的药方。
### 1.3 游戏玩法
&emsp;&emsp;一次配置药方和一次收集药材为一个回合，玩家需在规定回合内完成草药的收集和药方的配置。  
&emsp;&emsp;缺失药方为 **《桂枝汤》**，所缺药材为**甘草**和**生姜**，玩家需采集各种药草以身试药，并根据效果进行调整。药材属性获得时不显示，玩家只能通过产生的状态判断，(产生相应状态后可解锁药材卡片，得知药性)。  
&emsp;&emsp;药性分为热、寒、毒三种，玩家试药过程中，会根据草药不同的药性产生相应的效果，不同药性分开计算、效果可叠加。  
&emsp;&emsp;所需药性为 __热(3),寒(2),毒(0)__，玩家所配药方药性超出所需值的部分即累加到自身状态，药方不匹配时提示错误，并相应显示所获得属性值。每回合结束玩家热、寒值减1、毒值两回合减1。  
## 2 游戏系统
### 2.1 角色状态系统
&emsp;&emsp;角色若选择了错误的药草，会相应的获得减益状态，如寒性值过高则会导致肠胃不舒服，**移速降低、行动能力下降**；毒性过高会直接导致**游戏结束**；热性过高会头晕发热导致**键位顺序改变**等。  
&emsp;&emsp;寒值>=5时，寒值清零，角色获得移速降低效果，持续一回合。  
&emsp;&emsp;热值>=5时，热值清零，角色获得键位顺序改变效果，持续一回合。  
&emsp;&emsp;毒值>=5时，角色死亡，游戏结束。  
### 2.2 背包系统
&emsp;&emsp;通过游历采药捡拾场景中各种药草，背包上限为四格，每次最多只能采集四种药材，可重复、不可累加、可丢弃。
## 3 游戏道具
### 3.1 桂枝汤药方
&emsp;&emsp;桂枝汤作为《伤寒杂病论》中的典型方剂之一，具有辛温解表，解肌发表，调和营卫之功效。主治头痛发热，汗出恶风，鼻鸣干呕，苔白不渴，脉浮缓或浮弱者。  
&emsp;&emsp;成分： __桂枝__ 、 __芍药__ 、 _甘草_ 、 __大枣__ 、 _生姜_ 。 ___(热(3),寒(2),毒(0))___  
&emsp;&emsp;歌诀：太阳中风桂枝汤，芍药甘草枣生姜。解肌发表调营卫，啜粥温服汗易酿。
### 3.2 草药
* 已有草药：
  * __桂枝__： *辛；甘；性温。* __热(1),寒(0),毒(0)__
  * __芍药__： *苦、酸，微寒。* __热(0),寒(2),毒(0)__
  * __大枣__： *甘，性温。* __热(1),寒(0),毒(0)__
  * 干姜： *辛，性热。* __热(3),寒(0),毒(0)__
* 采集草药：
  * __甘草__：甘，性平。砂质壤土、丘陵地带。 __热(0),寒(0),毒(0)__
  * __生姜__：辛，性温。坡地和稍阴的地块，砂壤上。 __热(1),寒(0),毒(0)__
  * 板蓝根：苦，性寒。砂质壤土、山地林缘潮湿。 __热(0),寒(3),毒(0)__
  * 华山参：甘，性热，有毒。山坡、山沟、草地。 __热(3),寒(0),毒(2)__
  * 半夏：辛，温，有毒。野生于山坡、溪边阴湿的草丛中或林下。 __热(1),寒(0),毒(2)__
  * 白茅根：甘，寒。低山带平原河岸草地、沙质草甸。 __热(0),寒(3),毒(0)__
## 4 地图设计
### 4.1 书房
&emsp;&emsp;角色可在书房中配置药品并进行试药。场景中可放置制药台、药炉、药柜等可交互物品。
### 4.2 坡地
&emsp;&emsp;场景地图有地形起伏、地面为草地以及稀疏树木，有河流经过，有可交互草药分布。角色可在地形中移动进行，并收集草药。
## 5 游戏美术及音乐
&emsp;&emsp;游戏美术及音乐均采用免费资源，对于简单模型团队成员可尝试自主建模。
