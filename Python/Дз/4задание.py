x=float(input('Введи число:'))
s=0
mn=x
mx=x
while x!=7:
    if x<mn:
        mn=x
    if x>mx:
        mx=x
    s+=x
    print(s,mx,mn)
    x=float(input('Введи новое число:'))
print('Good bye!')