"""
a=int(input())
b=int(input())
kol=0#кол-во простых чисел от a до b
for i in range(a,b+1):
    k=0
    for j in range(2,int(i**0.5)+1):
        if i%j==0:
            k+=1
            break
    if k==0:
        kol+=1
        #print(i)
print('Кол-во:',kol) 
"""   
# LIFO - last input first output
# FIFO - first input first output
a=[]
sum=0
for i in range(1,101):
    a.append(i)
for i in range(len(a)):
    if i%2!=0:
        sum+=a[i]
"""
for i in range(0,100):
    a.append(i+1)
    if i%2!=0:
        sum+=a[i]
    if a[i]%2==0:
        sum1+=a[i]
"""
print(a)
print(sum,sum)