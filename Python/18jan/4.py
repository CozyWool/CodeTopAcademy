a=int(input('Введите нижнюю границу диапазона '))
b=int(input('Введите верхнюю границу диапазона '))
n=int(input('Введите кол-во элементов '))
c=[]
for i in range(n):
    c.append(int(input('Введите число ')))

for i in c:
    if i in range(a,b+1):
        print(i**3)
    else:
        print('Error')