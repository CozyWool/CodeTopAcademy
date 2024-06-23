from MyModule import summa,maxmimum
a=[] #шапка таблицы
klass=[] #весь учебный класс
while True:
    #Что хочет пользователь
    print('Если вы хотите создать новый журнал, введите 1')
    print('Если вы хотите добавить ученика в класс, введите 2')
    print('Если вы хотите увидеть журнал класса, введите 3')
    print('Если вы хотите узнать средний балл класса по каждому предмету, введите 4')
    print('Если вы хотите узнать средний балл ученика, введите 5')
    print('Если вы хотите найти отличников, введите 6')
    print('Если вы хотите найти ударников, введите 7')
    print('Если вы хотите найти троечников, введите 8')
    print('Если вы хотите найти двоечников, введите 9')
    
    t=int(input())
    if t==1:#Новый журнал
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
    if t==2:#Добавить нового ученика
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r+',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
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
    if t==3:#Увидеть журнал класса
        klass.clear()
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        for i in klass:
            print(i)
    if t==4:#Средний балл всего класса по каждому предмету
        klass.clear()
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        sm=0
        for i in range(1,6):
            for j in range(1,len(klass)):
                sm+=int(klass[j][i])
            print('Средний балл по предмету'+klass[0][i],sm/(len(klass)-1))
            sm=0
    if t==5:#Средний балл ученика
        klass.clear()
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        sm=0
        for j in range(1,len(klass)):
            for i in range(1,6):
                sm+=int(klass[j][i])
            print('Средний балл ученика',klass[j][0],'=',sm/5)
            sm=0
    if t==6:#Найти отличников
        klass.clear()
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
                print('Отличник:'+klass[i][0])
    if t==7:#Найти ударников
        klass.clear()
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        for i in range(1,len(klass)):
            k=0
            for j in range(1,6):
                if int(klass[i][j])==5 or int(klass[i][j])==4:
                    k+=1
            if k==5:
                print('Ударник:'+klass[i][0])
    if t==8:#Найти троечников
        klass.clear()
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        for i in range(1,len(klass)):
            k=0
            for j in range(1,6):
                if int(klass[i][j])==3:
                    k+=1
            if k>=1:
                print('Троечник:'+klass[i][0])
    if t==9:#Найти двоечников
        klass.clear()
        kl=input('Введите название класса:')
        f=open(kl+'.txt','r',encoding='utf')
        s=f.read().splitlines()
        for i in s:
            klass.append(i.split(','))
        for i in range(1,len(klass)):
            k=0
            for j in range(1,6):
                if int(klass[i][j])==2:
                    k+=1
            if k>=1:
                print('Двоечник:'+klass[i][0])