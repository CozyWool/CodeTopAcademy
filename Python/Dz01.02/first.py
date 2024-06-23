s=input().split()
d={}
for i in s:
    s,b=i.split('=')
    d[s]=b
print(*sorted(d.items()))