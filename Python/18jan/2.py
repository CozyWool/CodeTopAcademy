n=int(input('Введите кол-во элементов '))
a=[]
for i in range(n):
    a.append(int(input('Введите число ')))
for i in range(n):
    k=0
    for j in range(n):
        if a[i]==a[j]:
            k+=1
    if k==1:
        print('Уникальное число',a[i])
