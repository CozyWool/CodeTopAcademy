a=[] #шапка таблицы
klass=[] #весь учебный класс
while True:
    print('Если вы хотите создать новый журнал, введите 1')
    print('Если вы хотите добавить ученика в класс, введите 2')
    print('Если вы хотите увидеть журнал класса, введите 3')
    print('Если вы хотите найти отличников, введите 4')
    print('Если вы хотите узнать средний балл класса по каждому предмету, введите 5')
    t=int(input())
    if t==1:
        kl=input('Введите название класса:')
        f=open(kl+'.txt','a+',encoding='utf')
        a.append('Ф.И.О')
        for i in range(5):
            a.append(input('Введите предмет:'))
        klass.append(a)
        x=str(a)
        f.write(x[1:len(x)-1]+'\n')
    
        padavan=int(input('Введите кол-во учеников в '+kl+':'))
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
            z=str(b)
            f.write(z[1:len(z)-1]+'\n')
    if t==2:
        kl=input('Введите название класса:')
        f=open(kl+'.txt','a+',encoding='utf')
        b=[]#информация о ученике(строка таблицы)
        b.clear()
        b.append(input('Введите '+ klass[0][0] + ' '))
        b.append(int(input('Введите оценку по предмету '+ klass[0][1]+ ' ')))
        b.append(int(input('Введите оценку по предмету '+ klass[0][2]+ ' ')))
        b.append(int(input('Введите оценку по предмету '+ klass[0][3]+ ' ')))
        b.append(int(input('Введите оценку по предмету '+ klass[0][4]+ ' ')))
        b.append(int(input('Введите оценку по предмету '+ klass[0][5]+ ' ')))
        z=str(b)
        f.write(z[1:len(z)-1]+'\n')
    if t==3:
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        for i in klass:
            print(i)
    if t==4:
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        for i in range(1,len(klass)):
            k=0
            for j in range(1,6):
                if int(klass[i][j])==5:
                    k+=1
            if k==5:
                print(klass[i][0])
#Средний балл всего класса по каждому предмету
    if t==5:
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        for i in range(1,6):
            for j in range(1,padavan+1):
                sm+=klass[j][i]
        print('Средний балл по предмету',klass[0][i],sm/padavan)
        sm=0