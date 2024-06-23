a=[1,2,3,4,5]
mx=0
mn=a[0]
sm=0
chet=0
for i in a:
    if i>mx:
        mx=i
    if i<mn:
        mn=i
    sm+=i