# 最小成本生成樹

## 以下三種演算法及定義(以我自己的說法，如有錯誤還請見諒)
* ## Prim
* * ## 從任一起點開始，挑最小權重且未走過的節點(必須連通)，直到所有的節點都走過為止(等同於n-1條邊)。
* ## Kruskal
* * ## 每次挑選一條最小權重的邊加入圖形，且加入這條邊不會形成迴圈，加入至n-1條邊為止。
* ## Sollin's
* * ## 對每一個點挑選一條權重最小的邊，組合成一張圖，如果最後圖形不為一張，則選擇可以連通的邊且權重最小的邊加入到成為一張圖為止。

輸入:<br>
10<br>
A,B,1 A,C,2 A,D,4 B,C,3 C,D,5 B,E,7 E,D,6<br>
A,C,1 A,B,2 A,D,3 C,B,4 C,D,5 B,D,6<br>
A,B,1 A,C,2 C,E,10 E,D,7 B,D,3 B,G,5 B,F,8 D,F,11 F,H,9 G,F,4 G,H,6<br>
E,F,10 E,K,17 C,F,16 C,E,18 C,D,14 D,K,15 D,J,5 K,J,4 C,G,11 G,H,7 H,I,1 I,J,2 B,J,3 B,D,6 B,A,8 A,H,9 A,C,12 A,D,13<br>
A,B,7 A,C,12 A,F,2 B,F,3 B,D,5 B,E,14 C,D,1 C,F,18 D,F,10 E,D,4<br>
A,B,6 A,E,3 A,F,4 A,G,1 B,C,2 B,D,3 B,F,5 C,D,1 D,E,6 D,F,4 E,F,5 E,G,2<br>
A,B,1 A,E,1 A,F,1 A,G,1 B,C,1 B,D,1 B,F,1 C,D,1 D,E,1 D,F,1 E,F,1 E,G,1<br>
A,B,1 A,E,1 A,F,1 B,D,1 B,F,1 D,E,1 D,F,1 E,F,1<br>
A,B,1 A,C,1 A,F,1 B,F,1 B,D,1 B,E,1 C,D,1 C,F,1 D,F,1 E,D,1<br>
U,V,11 U,R,17 U,T,14 V,Q,15 V,R,11 R,A,12 S,A,7 T,S,12 S,B,22 S,L,21 S,K,11 A,F,3 B,L,4 K,P,6 X,W,11 X,Y,12 W,C,21 C,E,8 E,B,9 L,D,11 L,P,31 C,N,22 F,D,11 P,H,12 P,M,7 L,O,8 Y,Z,12 Z,J,14 Y,J,16 J,N,15 J,G,14 G,I,13 N,I,12 I,O,9 G,H,10 G,D,12 O,M,18 U,S,4 V,A,2 R,B,3 T,K,7 Q,A,14 A,B,11 B,K,12 Q,X,5 A,W,1 A,C,2 A,E,4 E,F,16 B,D,3 K,L,7 W,Y,6 W,Z,8 C,J,9 C,G,10 D,P,4 D,H,14 G,N,13 H,I,16 H,O,12 H,M,14 R,S,7<br>

輸出:<br>
13<br>
6<br>
28<br>
67<br>
15<br>
14<br>
6<br>
4<br>
5<br>
152