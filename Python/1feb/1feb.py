"""
d={'Russia':'Moscow','USA':'Washington','UK':'London','Germany':'Berlin'}
a=input('Укажите страну:')
print(d.get(a,'Нет такой страны'))  
"""
"""
a=439849393544350999824*64
d={}
s=str(a)
print(s)
for i in range(10):
    d[i]=s.count(str(i))
print(d)
"""


s=open('name.txt','r',encoding='utf')
f=s.read().split()
a=[]
for i in range(33,65):
    a.append(chr(i))
for i in range(len(f)):
    if len(f[i])<=3 or f[i] in a:
        f[i]=''
for i in f:
    for j in i:
        if j in a:
            j=''
slova={}
r=''
r=f
for i in r:
    slova[i]=r.count(i)
print(slova)
print(len(f))
