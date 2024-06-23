a=int(input('Введи первое число:'))
b=int(input('Введи второе число:'))
s1=0
s2=0
s9=0
c1=0
c2=0
c9=0
while a<=b:
    if a%2==0:
        s2+=a
        c2+=1
    if a%2!=0:
        s1+=a
        c1+=1
    if a%9==0:
        s9+=a
        c9+=1
    a+=1
print(s1,s2,s9)
if c1!=0:
    print(s1/c1)
if c2!=0:
    print(s2/c2)
if c9!=0:
    print(s9/c9)   
        
    