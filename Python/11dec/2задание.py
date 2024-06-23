b=[]
b=input().split()
summ=0
maxx=0
minn=b[0]
for i in b:
    summ+=int(i)
    if int(i)>maxx:
        maxx=int(i)
    if int(i)<int(minn):
        minn=int(i)
print(maxx,minn,summ)