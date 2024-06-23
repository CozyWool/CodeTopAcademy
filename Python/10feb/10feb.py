"""
# ax^2+bx+c=0
def d(a,b,c):
    return b**2-4*a*c

def x(a,b):
    print(-b/2/a)

def xx(a,b,c):
    print((-b+(d(a,b,c)**0.5))/2/a)
    print((-b-(d(a,b,c)**0.5))/2/a)


a=int(input())
b=int(input())
c=int(input())

if d(a,b,c)==0:
    x(a,b)
elif d(a,b,c)>0: 
    xx(a,b,c)
else:
    print('Корней нет')
"""

def f(x):
    return -x**2+8*x-12

e=1e-20#float(input())
try:
    a=float(input())
    b=float(input())
except:
    print('Неверный ввод')
while b-a>e:
    c=(a+b)/2
    if f(c)*f(b)<0:
        a=c
    else:
        b=c
print(a+b)
