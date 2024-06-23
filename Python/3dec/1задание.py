a=int(input())
b=int(input())
for i in range(a,b+1):
    k=0
    for j in range(2,int(i**0.5)+1):
        if i%j==0:
            k+=1
            break
    if k==0:
        print(i)    
