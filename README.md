# Isob — 2D 类魂动作游戏

Isob 是一款使用 Unity 开发的 2D 横版动作平台游戏，采用 **状态机驱动** 的战斗系统与 **类魂（Souls-like）** 设计理念。玩家需要操控角色穿越危险的关卡，对抗多种敌人，收集装备并解锁强力技能。

## ✨ 核心特性

### 🗡️ 战斗系统

- **连击攻击**：三段式普攻连击，节奏紧凑，可衔接多种派生
- **冲刺翻滚**：短暂无敌帧 + 快速位移，是躲避敌人攻击的核心手段
- **弹反（Parry）**：精准的弹反窗口，成功弹反可反击敌人
- **墙滑 & 墙跳**：流畅的 2D 平台操作手感
- **多段跳跃**：支持空中多段跳跃，探索更自由
- **无敌帧与硬直**：完整的受击反馈，包括闪烁、击退、眩晕状态

### 🧙 技能系统

| 技能                  | 说明                                                         |
| --------------------- | ------------------------------------------------------------ |
| **Dash（冲刺）**      | 快速向前冲刺，附带短暂无敌                                   |
| **Sword（飞剑）**     | 投掷/操控飞剑远程攻击                                        |
| **Clone（分身）**     | 召唤分身辅助战斗                                             |
| **Blackhole（黑洞）** | 释放黑洞吸引并伤害敌人                                       |
| **Crystal（水晶）**   | 放置水晶，再次使用可瞬移到水晶位置（已实现，待接入 SkillManager） |

### 👹 敌人类型

游戏内设计了多种 AI 敌人，每种都有独立的状态机行为：

- **Skeleton（骷髅）** — 近战攻击型，移动与攻击节奏明确
- **Slime（史莱姆）** — 弹跳冲撞型，地面与空中行为不同
- **Archer（弓箭手）** — 远程射击型，会闪避玩家突进
- **NightBorne（夜行者）** — 高机动近战型，攻击迅猛
- **Necro（死灵法师）** — 远程施法型，发射死亡之球

### 🎒 物品与装备系统

- **背包（Inventory）**：管理消耗品、装备、材料
- **装备系统**：武器、防具可附加力量、暴击、护甲等属性
- **物品效果**：吸血、暴击、速度、雷击、魔法弹、荆棘等多种特效
- **消耗品**：生命药水（普通/强化），快速回血
- **Buff 系统**：速度增益、元素伤害加成等多种 Buff

### 📊 属性成长系统

- **EntityStatistic** 驱动的属性计算：力量、暴击率、魔法、护甲、魔抗、生命
- **Value 类** 实现基础值 + 加法修正 + 乘法修正的数值模型
- 敌人按等级动态强化，掉落对应等级物品

### 💾 存档系统

- 基于文件的存档读写（FileDataHandler）
- 自动保存玩家进度与背包状态

## 🎮 操作说明

| 按键               | 功能                        |
| ------------------ | --------------------------- |
| `A` / `D` 或 ← / → | 左右移动                    |
| `Space` / `K`      | 跳跃 / 多段跳 / 墙跳        |
| `Left Shift`       | 冲刺翻滚                    |
| `鼠标左键` / `J`   | 普攻连击                    |
| `F`                | 弹反（Counter Attack）      |
| `Q`                | 飞剑技能（按住瞄准 / 投掷） |
| `R`                | 黑洞技能                    |
| `1`                | 使用生命药水                |
| `S` + `Space`      | 下落穿越平台                |

## 🛠️ 技术栈

- **游戏引擎**：Unity 2022.x（URP 12.1.13）
- **渲染管线**：Universal Render Pipeline (URP) 2D
- **开发语言**：C#
- **核心依赖**：
  - TextMesh Pro
  - Unity 2D Feature (Sprite, Physics2D, Tilemap)
  - Unity Visual Scripting
  - Unity Cinematic (Timeline)

## 📁 项目结构

```
Assets/
├── Animation/          # 动画控制器与动画片段
│   ├── Player/         # 玩家全部动画状态
│   ├── Enemy/          # 各敌人动画（Archer, Necro, NightBorne, Skeleton, Slime）
│   ├── Candela/        # 火把等场景动画
│   ├── Clone/          # 分身技能动画
│   ├── Crystal/        # 水晶技能动画
│   ├── FX/             # 特效动画（火焰、受击、暴击）
│   ├── MagicBullet/    # 魔法弹动画
│   ├── Necro's Ball/   # 死灵法师死亡之球
│   ├── ThunderStrike/  # 雷击特效
│   └── sword/          # 飞剑动画
├── Audio/              # 背景音乐与音效
├── Data/               # ScriptableObject 数据（Buff 等）
├── Graphics/           # 字体资源
├── Material/           # 物理材质
├── Script/             # 核心 C# 脚本 ⭐
│   ├── Player/         # 玩家脚本 + 状态机
│   │   └── StateScript/    # 玩家状态（Idle, Move, Jump, Attack, Dash, WallSlide 等）
│   ├── Emeny/          # 敌人脚本 + 状态机 + 动画事件
│   │   └── StateScript/    # 各敌人独立状态实现
│   ├── Skill/          # 技能系统（Dash, Sword, Clone, Blackhole, Crystal）
│   │   └── Controller/     # 技能弹幕/特效控制器
│   ├── Item adn Inventory/  # 背包、装备、物品效果
│   │   └── ItemEffect/     # 吸血、荆棘、雷击、魔法弹等效果
│   ├── Statictis/      # 属性统计系统（力量、暴击、Buff 乘区）
│   ├── Buff/           # Buff/Debuff 系统
│   ├── Manager/        # 单例管理器（Game, Audio, Player, Skill, Save）
│   ├── SaveAndLoad/    # 存档读写
│   ├── Audio/          # 音频控制器（玩家、敌人、实体）
│   ├── UI/             # UI 组件（血条、伤害数字、装备槽、主菜单等）
│   ├── Entity.cs       # 实体基类（碰撞、攻击、受击）
│   ├── EntityFX.cs     # 实体特效
│   └── ParallaxBackground.cs  # 视差滚动背景
├── Shader/             # Shader Graph
└── TextMesh Pro/       # TMP 字体与示例
```

## 🎯 架构设计

### 状态机模式

玩家与敌人均采用 **独立状态机** 驱动行为：

- 每个状态继承自 `PlayerState` / `EnemyState` 基类
- 通过 `Machine` 类管理状态切换
- 状态切换由输入、碰撞检测、计时器等条件触发

### 核心类继承关系

```
Entity (实体基类：碰撞、攻击、翻转、受击特效)
 ├── Player (玩家：移动、跳跃、冲刺、连击、弹反、无敌)
 │    └── PlayerStatistic (玩家专属属性 + 暴击 + 死亡判定)
 └── Enemy (敌人：AI、检测玩家、冷却、眩晕)
      ├── Enemy_Skeleton / Slime / Archer / NightBorne / Necro
      └── EnemyStatistic (敌人等级成长 + 掉落)
```

### 数据驱动属性系统

```
EntityStatistic
 ├── Value (力量、暴击、护甲等 — 基础 + 加法 + 乘法)
 ├── 伤害计算 (普通 / 暴击 / 魔法)
 └── Buff/Debuff (速度、元素伤害等乘区)
```

## 🚀 快速开始

### 环境要求

- Unity 2022.x（推荐 2022.3 LTS）
- 安装 URP 2D Feature 包

### 打开项目

1. 使用 Unity Hub 选择 **Open** → 指向项目根目录
2. Unity 将自动导入所有资源（首次打开可能需要几分钟）
3. 通过 **File → New Scene** 创建新场景，将核心预制体（Player、Enemy 等）拖入场景即可开始测试
4. 点击 Play 按钮运行

## 📝 备注

> ⚠️ `.gitignore` 文件当前存在未解决的 Git 合并冲突标记（`<<<<<<< HEAD` / `>>>>>>>`），建议合并清理后再提交代码。
