n=int(input('Введите кол-во элементов '))
a=[]
for i in range(n):
    a.append(int(input('Введите число ')))

for i in range(0,n-n%2,2):
    a[i+1],a[i]=a[i],a[i+1]
for i in a:
    print(i)
    