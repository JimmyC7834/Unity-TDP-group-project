# 塔防 PARTY GAME (暫定)
### Created by:
- [JimmyC7834](https://github.com/JimmyC7834)
- [JoelLei121](https://github.com/JoelLei121)
- [JimmyYeung25](https://github.com/JimmyYeung25)
---
## 概述
塔防類型party game, 會有怪從四方八面跟住預定路線(暫定)進攻,
玩家於地圖內到處遊走, 一路合作收集資源, 一路起砲塔保護並維護於地圖(暫定正方形)中央的核心

- 引擎： unity 2020.3.19f1
- 砲塔類型: 未定, 大概兩三種
- 資源類型: 木材, 鐵(金屬)
- 人數：2-4 (6)人 (對戰模式: 1,2,3人一隊)
---

## 玩法系統(適用於對戰模式, 到時再改改)
#### 玩家
- 有不同職業對應不同特性
    - 收集資源速度加快, 維修速度加快, 揼嘢揼遠啲
- 可以搬, 甚至投擲砲塔
    - 搬砲塔哥陣玩家速度會減慢

#### 砲塔
- 預計製作流程: 收集資源 -> 搬資源去製作處 -> 等待製作過程 -> 出爐
- 有耐久度, 一定射擊次數之後就會爆炸
    - 爆炸會不分敵我對周圍造成傷害
- 可以消耗資源來維修砲塔回復耐久, 需要一定時間
- 可以被玩家搬走, 甚至投擲
    - 畀人搬緊嘅時候不會攻擊
- 會阻路
- 預想砲塔唔會好多, 每個玩家可能Keep住維護兩三個

#### 敵人
- 基本冇AI, 淨係跟住路軌行去進攻核心
- 到後期越厚血, 越多
- 會撞死玩家(敵人同時死亡), 消失一段時間
- 撞到砲塔會消耗砲塔耐久(敵人同時死亡)
- 砲塔可以被揼過敵人 (從敵人頭上飛過去)

#### 資源
- 於地圖範圍內隨機生成 (或者固定?
- 要由玩家手動收集並搬動
    - 可以週街放, 需要嘅時候再攞嚟用都得
- 用於製作維修砲塔及核心供給(維護)

#### 地圖
- 會隨機生成唔畀行嘅地形
- 隨機制定敵人嘅路線

#### 核心
- 可以喺任何形式, 暫時未諗到
- 砲塔嘅能源供給
- 要一直消耗資源維持能源供給, 否則砲塔將會罷工

#### 額外選項 (未定Idea, 或者可能作為隨機事件加入遊戲)
- 玩家之間嘅塔會擊倒對方
- 其間會出現道具幫助玩家去收集資源或干擾對手
- 玩家一定範圍之內會弱化隊友起嘅砲塔
- 有個特殊裝置小範圍內強化砲塔射速
    - 可以快啲整爆隊友啲嘢
- 有個特殊裝置小範圍內升級(強化)砲塔
    - 要同隊友爭 (?
---

## 合作模式概要
- rouge-like: 打一關 -> 攞強化 -> 重複 (5-10分鐘一關)
- 每關隨機地圖, 資源位置 + 隨機事件
- 唔同嘅強化令到後期可以有唔同流派
    - 例如: 自爆流, 射爆流, 數量流

## 對戰模式概要
- 暫定兩隊對戰
- 地圖分為兩邊, 一隊一邊
- 可以起特殊裝置捉敵人, 然後執起揼過對面 (或者傳送過對面)
- 幹擾對方令對方失守, 或者倒數結束計分 (5-10分鐘)
---

# 第零階段目標
- Setup GitHub, Unity, Vscode (+插件)
- Clone 主要repo 到自己電腦上
- 實習一次流程 -> 提交issue -> 改嘢 -> commit -> push -> PR -> review -> merge

#### 完成進度：

- [x] JimmyC
- [x] JoelLei
- [x] DanielLao
- [x] JimmyY

---
# 第一階段目標：基本地圖，玩家控制, 基本交互, 基本敵人AI
## 基本地圖
- 地圖格
- 基本障礙物
- 敵人路線導航

## 玩家控制
- IO 管理
- 基本移動 + 互動操作
- 撿起東西

## 基本交互 -> 有反應就得, 唔使實現功能住
- 核心交互
- 資源交互
- 工廠交互
- 砲塔交互

## 敵人AI
- 冇, 跟住條線行就得