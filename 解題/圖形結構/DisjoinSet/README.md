直接讀到檔尾，有三個指令。<br>
makeSet 建立集合 後面有一個數字 代表建立幾個項目，第i個值為i，<br>
merge 合併，後面的節點指向前面的節點，<br>
list 列出當前的狀態<br>
輸入:<br>
makeSet 10<br>
merge {4} {5}<br>
list<br>
merge {4} {6}<br>
merge {1} {2}<br>
merge {2} {3}<br>
merge {7} {8}<br>
merge {8} {9}<br>
merge {10} {1}<br>
list<br>
makeSet 6<br>
list<br>
merge {1} {5}<br>
merge {3} {4}<br>
merge {4} {2}<br>
merge {4} {6}<br>
merge {3} {1}<br>
list<br>
輸出:<br>
Case 1:<br>
1<br>
2<br>
3<br>
4<br>
5->4<br>
6<br>
7<br>
8<br>
9<br>
10<br>
Case 2:<br>
1->10<br>
2->1->10<br>
3->2->1->10<br>
4<br>
5->4<br>
6->4<br>
7<br>
8->7<br>
9->8->7<br>
10<br>
<br>
Case 1:<br>
1<br>
2<br>
3<br>
4<br>
5<br>
6<br>
Case 2:<br>
1->3<br>
2->4->3<br>
3<br>
4->3<br>
5->1->3<br>
6->4->3