from random import randint

b=[]
sum1=0
sum2=0
sum3=0
proiz1=1
maxx=0
maxxi=0
minn=10
minni=0
mini=10
maxi=0
for i in range(10):
    b.append(randint(-10,10))
print(b)
for i in b:
    if i<0:
        #print('Отрицательное:',i)
        sum1+=i
    if i%2==0:
        #print('Четное:',i)
        sum2+=i
    else:
        #print('Нечетное:',i)
        sum3+=i
for i in range(len(b)):
    if i%3==0:
        #print(i)
        proiz1*=b[i]
    if b[i]>0 and i<mini:
        mini=i
    if b[i]>0 and i>maxi:
        maxi=i
sum4=0
for i in range(mini+1,maxi):    
    sum4+=b[i]
for i in range(len(b)):
    if b[i]<minn:
        maxx=b[i]
        minni=i
    if b[i]>maxx:
        maxx=b[i]
        maxxi=i
proiz2=1
for i in range(minni,maxxi):
    proiz2*=b[i]
print(sum1,sum2,sum3,proiz1,sum4,proiz2)
print(minni,maxxi,minn,maxx)