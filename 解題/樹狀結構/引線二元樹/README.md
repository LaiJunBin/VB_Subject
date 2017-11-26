```
輸入:(輸入有英文與數字，若真的不會一起測可分兩次)
4
S,D,A,C,H,B,R,T,Z,U
H,E,I,J,K,G,A,F
50,20,10,18,14,19,16,70,59,66,77,81,60,79,80
23,17,30,1,21
輸出:(第幾筆測資，每個節點的左子樹及右子樹，與引線連接到的值)
Case:1
current:B:
Left    :null
Right   :null
L_thread:A
R_thread:C

current:C:
Left    :B
Right   :null
L_thread:null
R_thread:D

current:A:
Left    :null
Right   :C
L_thread:null
R_thread:null

current:R:
Left    :null
Right   :null
L_thread:H
R_thread:S

current:H:
Left    :null
Right   :R
L_thread:D
R_thread:null

current:D:
Left    :A
Right   :H
L_thread:null
R_thread:null

current:U:
Left    :null
Right   :null
L_thread:T
R_thread:Z

current:Z:
Left    :U
Right   :null
L_thread:null
R_thread:null

current:T:
Left    :null
Right   :Z
L_thread:S
R_thread:null

current:S:
Left    :D
Right   :T
L_thread:null
R_thread:null


Case:2
current:A:
Left    :null
Right   :null
L_thread:null
R_thread:E

current:F:
Left    :null
Right   :null
L_thread:E
R_thread:G

current:G:
Left    :F
Right   :null
L_thread:null
R_thread:H

current:E:
Left    :A
Right   :G
L_thread:null
R_thread:null

current:K:
Left    :null
Right   :null
L_thread:J
R_thread:null

current:J:
Left    :null
Right   :K
L_thread:I
R_thread:null

current:I:
Left    :null
Right   :J
L_thread:H
R_thread:null

current:H:
Left    :E
Right   :I
L_thread:null
R_thread:null


Case:3
current:16:
Left    :null
Right   :null
L_thread:14
R_thread:18

current:14:
Left    :null
Right   :16
L_thread:10
R_thread:null

current:19:
Left    :null
Right   :null
L_thread:18
R_thread:20

current:18:
Left    :14
Right   :19
L_thread:null
R_thread:null

current:10:
Left    :null
Right   :18
L_thread:null
R_thread:null

current:20:
Left    :10
Right   :null
L_thread:null
R_thread:50

current:60:
Left    :null
Right   :null
L_thread:59
R_thread:66

current:66:
Left    :60
Right   :null
L_thread:null
R_thread:70

current:59:
Left    :null
Right   :66
L_thread:50
R_thread:null

current:80:
Left    :null
Right   :null
L_thread:79
R_thread:81

current:79:
Left    :null
Right   :80
L_thread:77
R_thread:null

current:81:
Left    :79
Right   :null
L_thread:null
R_thread:null

current:77:
Left    :null
Right   :81
L_thread:70
R_thread:null

current:70:
Left    :59
Right   :77
L_thread:null
R_thread:null

current:50:
Left    :20
Right   :70
L_thread:null
R_thread:null


Case:4
current:1:
Left    :null
Right   :null
L_thread:null
R_thread:17

current:21:
Left    :null
Right   :null
L_thread:17
R_thread:23

current:17:
Left    :1
Right   :21
L_thread:null
R_thread:null

current:30:
Left    :null
Right   :null
L_thread:23
R_thread:null

current:23:
Left    :17
Right   :30
L_thread:null
R_thread:null
```