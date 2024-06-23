b=int(input('Введите кол-во одноклассников'))
a=[]
for i in range(b):
    a.append(int(input('Введите рост одноклассника')))
x=int(input('Введите свой рост'))
k=0
for i in a:
    if i>x:
        k+=1
print('Ваша позиция в строю',k+1)