n1=int(input())
a=[]
for i in range(n1):
    a.append('I')
n2=int(input())
for i in range(n2):
    c=int(input())
    b=int(input())
    for j in range(c-1,b):
        a[j]='.'
print(a)