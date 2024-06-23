f=open('17.txt')
s=f.read().splitlines()
d=[]
for i in s:
    d.append(int(i))
k=0
mxsm=0
for i in range(len(d)-2):
    a=d[i]
    b=d[i+1]
    c=d[i+2]
    mx=max(a,b,c)
    mn=min(a,b,c)
    md=a+b+c-mx-mn
    if mx<mn+md and mx**2<mn**2+md**2:
        k+=1
        if a+b+c>mxsm:
            mxsm=a+b+c
print(k,mxsm)

