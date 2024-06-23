#S=3,14*r^2
import math
#P=3,14*d
"""
d=int(input())
a=int(input('Что вы хотите узнать? 1 - площадь окружности, 2 - периметр окружности: '))
if a==1:
   print(3.14*(d/2)**2)
elif a==2:
    print(3.14*d)
"""
"""
a=int(input('Цена одной приставки: '))
b=int(input('Количество приставок: '))
c=int(input('Процент скидки: '))
d=int(input('Что вы хотите узнать? 1 - общая сумма заказа, 2 - стоимость одной приставки с учетом скидки: '))
if d==1:
    print(a*b-(a/100*c))
elif d==2:
    print(a-(a/100*c))
"""
"""
a=int(input())
if a in range(100000,1000000):
    if a//100000+a//10000%10+a//1000%10==a%1000//100+a%100//10+a%10:
        print('Cчастливое')
    else:
        print('Несчастливое')
    if a//100000==a%10 and a//10000%10==a%100//10 and a//1000%10==a%1000//100:
        print('Полиндром')
else:
    print('<>')
"""
"""
a=int(input())
if a in range(100000,1000000):
    first=a//100000
    second=a//10000%10
    fifth=a%100//10
    sixth=a%10
    print(a-first*100000+sixth*100000-sixth+first-fifth*10+second*10-second*10000+fifth*10000)
    print(str(a%10)+str(a%100//10)+str(a//100%100)+str(a//10000%10)+str(a//100000))
else:
    print('<>') 
"""
winter=[1,2,12]
spring=[3,4,5]
summer=[6,7,8]
autumn=[9,10,11]
a=int(input())
if a in winter:
    print('Winter')
elif a in spring:
    print('Spring')
elif a in summer:
    print('Summer')
elif a in autumn:
    print('Autumn')
