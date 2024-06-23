a=int(input())
b=int(input())
l=[]
prost=[]#кол-во простых чисел от a до b
chet=0
halfprost=0
for i in range(a,b+1):
    l.append(i)
for i in l:
    k=0
    for j in range(2,int(i**0.5)+1):
        if i%j==0:
            k+=1
            break
    if k==0:
        prost.append(i)
        print(i)
    if i%2==0:
        chet+=1
for i in prost:
    for j in prost:
        print('Полупростое:',i*j)
        if i*j in l:
            halfprost+=1
print('Кол-во четных:',chet) 
print('Кол-во простых:',len(prost))
print('Кол-во полупростых:',halfprost)  
