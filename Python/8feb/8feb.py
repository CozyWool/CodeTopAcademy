"""
t=0
for i in range(10**6,2**10**6,2):
    sm=0
    k=0
    for j in range(2,int(i**0.5)+1):
        if i%j==0:
            k+=1
            break
    if k==0:
        if len(str(i))!=len(set(str(i))):
            t+=1
print(t)
"""
"""
a=int(input())
b=int(input())
c=int(input())
if a+b+c==180:
    if (a==b and b!=c) or (a==c and c!=b) or(b==c and c!=a):
        print('OK')
else: print('NOT OK')
"""
"""
f=open('17.txt')
s=f.read().splitlines()
k=0
mxsm=0
for i in range(len(s)-1):
    a=int(s[i])
    b=int(s[i+1])
    if a%160!=b%160 and (a%7==0 or b%7==0):
        k+=1
        if a+b>mxsm:
            mxsm=a+b
print(k,mxsm)
"""
a=3
b=4
c=5
print(min(a,b,c))