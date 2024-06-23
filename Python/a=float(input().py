"""
# круг 109 км, скорость и время дано, узнать где остановится
speed=int(input('Скорость:'))
time=int(input('Время: '))
print('Если поедет вперед,остановится на:'+ str(speed * time%109),'км')
print('Если поедет назад,остановится на:'+ str(109-speed*time%109),'км')
"""
"""
# xxyy xx+yy xx-yy xx*yy
a=int(input('Введи четырехзначное число:'))
b=a//100
c=a%100
print(b+c, b-c, b*c)
"""
"""
a=int(input('Введи число:'))
b=int(input('Введи какой процент надо найти:'))
print(a/100*b)
"""
"""
a=int(input('Введи длину прямоугольника:'))
b=int(input('Введи ширину прямоугольника:'))
print('Площадь прямоугольника:',a*b)
"""
Surname=input()
Name=input()
Otchestvo=input()
print(Surname,Name[0]+'.',Otchestvo[0]+'.')