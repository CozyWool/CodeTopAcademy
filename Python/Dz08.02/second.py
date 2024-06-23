f=open('17a.txt')
s=f.read().splitlines()
d=[]
for i in s:
    d.append(int(i))
k=0
mxsm=0
for i in range(len(d)-1):
    for j in range(i+1,len(d)):
        a=d[i]
        b=d[j]
        if (a+b)%162==0:
            k+=1
            if a+b>mxsm:
                mxsm=a+b
print(k,mxsm)