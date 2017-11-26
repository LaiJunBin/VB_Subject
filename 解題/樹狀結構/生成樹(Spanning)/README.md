## BFS

```
輸入:(以A為起點)
10
A,B A,C C,F C,G E,H F,H B,D B,E D,H G,H
A,B A,C A,D B,C C,D B,E E,D
A,C A,B A,D C,B C,D B,D
A,B A,C C,E E,D B,D B,G B,F D,F F,H G,F G,H
E,F E,K C,F C,E C,D D,K D,J K,J C,G G,H H,I I,J B,J B,D B,A A,H A,C A,D
A,B A,C A,F B,F B,D B,E C,D C,F D,F E,D
A,B A,E A,F A,G B,C B,D B,F C,D D,E D,F E,F E,G
A,B A,E A,F A,G B,C B,D B,F C,D D,E D,F E,F E,G
A,B A,E A,F B,D B,F D,E D,F E,F
A,B A,C A,F B,F B,D B,E C,D C,F D,F E,D
輸出:
A,B, A,C, B,D, B,E, C,F, C,G, D,H
A,B, A,C, A,D, B,E
A,C, A,B, A,D
A,B, A,C, B,D, B,G, B,F, C,E, G,H
A,B, A,H, A,C, A,D, B,J, H,G, H,I, C,F, C,E, D,K
A,B, A,C, A,F, B,D, B,E
A,B, A,E, A,F, A,G, B,C, B,D
A,B, A,E, A,F, A,G, B,C, B,D
A,B, A,E, A,F, B,D
A,B, A,C, A,F, B,D, B,E
```

## DFS

```
輸入:(以A為起點)
10
A,B A,C C,F C,G E,H F,H B,D B,E D,H G,H
A,B A,C A,D B,C C,D B,E E,D
A,C A,B A,D C,B C,D B,D
A,B A,C C,E E,D B,D B,G B,F D,F F,H G,F G,H
E,F E,K C,F C,E C,D D,K D,J K,J C,G G,H H,I I,J B,J B,D B,A A,H A,C A,D
A,B A,C A,F B,F B,D B,E C,D C,F D,F E,D
A,B A,E A,F A,G B,C B,D B,F C,D D,E D,F E,F E,G
A,B A,E A,F A,G B,C B,D B,F C,D D,E D,F E,F E,G
A,B A,E A,F B,D B,F D,E D,F E,F
A,B A,C A,F B,F B,D B,E C,D C,F D,F E,D
輸出:
A,B,D,H,E,F,C,G
A,B,C,D,E
A,C,B,D
A,B,D,E,C,F,H,G
A,B,J,D,C,F,E,K,G,H,I
A,B,F,C,D,E
A,B,C,D,E,F,G
A,B,C,D,E,F,G
A,B,D,E,F
A,B,F,C,D,E
```