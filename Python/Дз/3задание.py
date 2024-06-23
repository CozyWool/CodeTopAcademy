x=float(input('Введи число:'))
while x!=7:
    if x>0:
        print('Number is positive')
    if x<0:
        print('Number is negative')
    if x==0:
        print('Number is equal to zero')
    x=float(input('Введи новое число:'))
print('Good bye!')