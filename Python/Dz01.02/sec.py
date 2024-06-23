s=input()
d={}
a,b=s.split('=')
d[a]=b
print(*sorted(d.items()))