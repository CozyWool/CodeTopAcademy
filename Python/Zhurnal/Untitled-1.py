def win(a):
    sgd=0
    spd=0
    ss=0
    sst=0
    for i in range(3):
        sgd+=a[i][i]#сумма главной диагонали
        
        for j in range(3):
            ss+=a[i][j]#сумма строк
            sst+=a[j][i]#сумма столбцов
        if ss==0 or sst==0 or sgd==0:
            return True
    for i in range(3):
        spd+=a[i][2-i]#сумма побочной диагонали
        if spd==0:
            return True
game=[[2,2,2],[2,2,2],[2,2,2]]
print(game)
step=0
while step<9:
    print('Введите координату ячейки')
    a=int(input('Строка:'))
    b=int(input('Столбец:'))
    if game[a][b]==2:
        if step%2==0:
            game[a][b]=1
            if win(game):
                print('Победил первый игрок')
                break
        if step==8:
            print('Ничья')
            break
        else:
            game[a][b]=0
            if win(game):
                print('Победил второй игрок')
                break
        for i in game:
            print(i)
        step+=1
    else:
        print('Клетка занята')
