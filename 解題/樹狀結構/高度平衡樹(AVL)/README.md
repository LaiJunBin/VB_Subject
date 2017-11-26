```
完整的輸出過程
EX1:
插入May後,無需修正

節點Mary是根節點,平衡因子為-1
節點May的父節點為:Mary,平衡因子為0

插入Mike後 失衡

節點Mary是根節點,平衡因子為-2
節點May的父節點為:Mary,平衡因子為-1
節點Mike的父節點為:May,平衡因子為0

使用RR修正後

節點May是根節點,平衡因子為0
節點Mary的父節點為:May,平衡因子為0
節點Mike的父節點為:May,平衡因子為0

插入Devin後,無需修正

節點May是根節點,平衡因子為1
節點Mary的父節點為:May,平衡因子為1
節點Devin的父節點為:Mary,平衡因子為0
節點Mike的父節點為:May,平衡因子為0

插入Bob後 失衡

節點May是根節點,平衡因子為2
節點Mary的父節點為:May,平衡因子為2
節點Devin的父節點為:Mary,平衡因子為1
節點Bob的父節點為:Devin,平衡因子為0
節點Mike的父節點為:May,平衡因子為0

使用LL修正後

節點May是根節點,平衡因子為1
節點Devin的父節點為:May,平衡因子為0
節點Bob的父節點為:Devin,平衡因子為0
節點Mary的父節點為:Devin,平衡因子為0
節點Mike的父節點為:May,平衡因子為0

插入Jack後 失衡

節點May是根節點,平衡因子為2
節點Devin的父節點為:May,平衡因子為-1
節點Bob的父節點為:Devin,平衡因子為0
節點Mary的父節點為:Devin,平衡因子為1
節點Jack的父節點為:Mary,平衡因子為0
節點Mike的父節點為:May,平衡因子為0

使用LR修正後

節點Mary是根節點,平衡因子為0
節點Devin的父節點為:Mary,平衡因子為0
節點Bob的父節點為:Devin,平衡因子為0
節點Jack的父節點為:Devin,平衡因子為0
節點May的父節點為:Mary,平衡因子為-1
節點Mike的父節點為:May,平衡因子為0

插入Helen後,無需修正

節點Mary是根節點,平衡因子為1
節點Devin的父節點為:Mary,平衡因子為-1
節點Bob的父節點為:Devin,平衡因子為0
節點Jack的父節點為:Devin,平衡因子為1
節點Helen的父節點為:Jack,平衡因子為0
節點May的父節點為:Mary,平衡因子為-1
節點Mike的父節點為:May,平衡因子為0

插入Joe後,無需修正

節點Mary是根節點,平衡因子為1
節點Devin的父節點為:Mary,平衡因子為-1
節點Bob的父節點為:Devin,平衡因子為0
節點Jack的父節點為:Devin,平衡因子為0
節點Helen的父節點為:Jack,平衡因子為0
節點Joe的父節點為:Jack,平衡因子為0
節點May的父節點為:Mary,平衡因子為-1
節點Mike的父節點為:May,平衡因子為0

插入Ivy後 失衡

節點Mary是根節點,平衡因子為2
節點Devin的父節點為:Mary,平衡因子為-2
節點Bob的父節點為:Devin,平衡因子為0
節點Jack的父節點為:Devin,平衡因子為1
節點Helen的父節點為:Jack,平衡因子為-1
節點Ivy的父節點為:Helen,平衡因子為0
節點Joe的父節點為:Jack,平衡因子為0
節點May的父節點為:Mary,平衡因子為-1
節點Mike的父節點為:May,平衡因子為0

使用RL修正後

節點Mary是根節點,平衡因子為1
節點Helen的父節點為:Mary,平衡因子為0
節點Devin的父節點為:Helen,平衡因子為1
節點Bob的父節點為:Devin,平衡因子為0
節點Jack的父節點為:Helen,平衡因子為0
節點Ivy的父節點為:Helen,平衡因子為0
節點Joe的父節點為:Jack,平衡因子為0
節點May的父節點為:Mary,平衡因子為-1
節點Mike的父節點為:May,平衡因子為0

插入John後 失衡

節點Mary是根節點,平衡因子為2
節點Helen的父節點為:Mary,平衡因子為-1
節點Devin的父節點為:Helen,平衡因子為1
節點Bob的父節點為:Devin,平衡因子為0
節點Jack的父節點為:Helen,平衡因子為-1
節點Ivy的父節點為:Helen,平衡因子為0
節點Joe的父節點為:Jack,平衡因子為-1
節點John的父節點為:Joe,平衡因子為0
節點May的父節點為:Mary,平衡因子為-1
節點Mike的父節點為:May,平衡因子為0

使用LR修正後

節點Jack是根節點,平衡因子為0
節點Helen的父節點為:Jack,平衡因子為1
節點Devin的父節點為:Helen,平衡因子為1
節點Bob的父節點為:Devin,平衡因子為0
節點Ivy的父節點為:Helen,平衡因子為0
節點Mary的父節點為:Jack,平衡因子為0
節點Joe的父節點為:Mary,平衡因子為-1
節點John的父節點為:Joe,平衡因子為0
節點May的父節點為:Mary,平衡因子為-1
節點Mike的父節點為:May,平衡因子為0

插入Peter後 失衡

節點Jack是根節點,平衡因子為-1
節點Helen的父節點為:Jack,平衡因子為1
節點Devin的父節點為:Helen,平衡因子為1
節點Bob的父節點為:Devin,平衡因子為0
節點Ivy的父節點為:Helen,平衡因子為0
節點Mary的父節點為:Jack,平衡因子為-1
節點Joe的父節點為:Mary,平衡因子為-1
節點John的父節點為:Joe,平衡因子為0
節點May的父節點為:Mary,平衡因子為-2
節點Mike的父節點為:May,平衡因子為-1
節點Peter的父節點為:Mike,平衡因子為0

使用RR修正後

節點Jack是根節點,平衡因子為0
節點Helen的父節點為:Jack,平衡因子為1
節點Devin的父節點為:Helen,平衡因子為1
節點Bob的父節點為:Devin,平衡因子為0
節點Ivy的父節點為:Helen,平衡因子為0
節點Mary的父節點為:Jack,平衡因子為0
節點Joe的父節點為:Mary,平衡因子為-1
節點John的父節點為:Joe,平衡因子為0
節點Mike的父節點為:Mary,平衡因子為0
節點May的父節點為:Mike,平衡因子為0
節點Peter的父節點為:Mike,平衡因子為0

插入Tom後,無需修正

節點Jack是根節點,平衡因子為-1
節點Helen的父節點為:Jack,平衡因子為1
節點Devin的父節點為:Helen,平衡因子為1
節點Bob的父節點為:Devin,平衡因子為0
節點Ivy的父節點為:Helen,平衡因子為0
節點Mary的父節點為:Jack,平衡因子為-1
節點Joe的父節點為:Mary,平衡因子為-1
節點John的父節點為:Joe,平衡因子為0
節點Mike的父節點為:Mary,平衡因子為-1
節點May的父節點為:Mike,平衡因子為0
節點Peter的父節點為:Mike,平衡因子為-1
節點Tom的父節點為:Peter,平衡因子為0
```