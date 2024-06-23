a=[] #шапка таблицы
klass=[] #весь учебный класс
kl=input('Введите название класса:')
f=open(kl,'a+',encoding='utf')
a.append('Ф.И.О')
for i in range(5):
    a.append(input('Введите предмет:'))
klass.append(a)
padavan=int(input('Введите кол-во учеников:'))
b=[]#информация о ученике(строка таблицы)
print(klass)
for i in range(padavan):
    b.clear()
    b.append(input('Введите '+ klass[0][0] + ' '))
    b.append(int(input('Введите оценку по предмету '+ klass[0][1]+ ' ')))
    b.append(int(input('Введите оценку по предмету '+ klass[0][2]+ ' ')))
    b.append(int(input('Введите оценку по предмету '+ klass[0][3]+ ' ')))
    b.append(int(input('Введите оценку по предмету '+ klass[0][4]+ ' ')))
    b.append(int(input('Введите оценку по предмету '+ klass[0][5]+ ' ')))
    klass.append(b)
for i in range(len(klass)): #вывод всего класса в столбик
    print(klass[i])
#средний балл класса по каждому предмету
#средний балл ученика
"""
sm=0

for i in range(1,6):
    for j in range(1,padavan+1):
        sm+=klass[j][i]
    print('Средний балл по предмету',klass[0][i],sm/padavan)
    sm=0
"""