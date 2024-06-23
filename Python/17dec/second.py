from random import randint

b=[]
mx=0
mn=0
plus=0
minus=0
zero=0
for i in range(15):
    b.append(randint(-10,10))
print(b)
for i in b:
    if i<mn:
        mn=i
    if i>mx:
        mx=i
    if i>0:
        plus+=1
    if i<0:
        minus+=1
    if i==0:
        zero+=1
print(mn,mx,minus,plus,zero)