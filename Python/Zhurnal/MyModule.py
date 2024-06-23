def summa(a):
    t=0
    for i in a:
        t+=i
    return t
def maxmimum(a):
    mx=a[0]
    for i in a:
        if i > mx:
            mx=i
    return mx
def hat():
    a=[]
    a.append('Ф.И.О')
    for i in range(5):
        a.append(input('Введите предмет:'))
    return(a)
def openklass(mode):
    klass=[]
    klass.clear()
    kl=input('Введите название класса:')
    f=open(kl+'.txt',mode,encoding='utf')
    s=f.read().splitlines()
    for i in s:
        klass.append(i.split(','))
    return klass,f
def maxx(a,b):
    if a>b:
        return True
    else:
        return False
def fact(a):
    if a<2:
        return 1
    if a>=1:
        return a*fact(a-1)
def poww(a,b):
    if b==0:
        return 1
    if b==1:
        return a
    if b>1:
        return a*poww(a,b-1)
def facct(a):
    t=1
    for i in range(1,a+1):
        t*=i
    return t
def supersearch(klass,b):
    for i in range(1,len(klass)):
            k=0
            for j in range(1,6):
                if int(klass[i][j])==b:
                    k+=1
            if k==5:
                print(klass[i][0])
def searchudar(klass):
    for i in range(1,len(klass)):
            k=0
            for j in range(1,6):
                if int(klass[i][j])==4 or int(klass[i][j])==5:
                    k+=1
            if k==5:
                print(klass[i][0])



