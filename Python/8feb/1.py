for i in range(10**6+1,2**10**9,2):
    k=0
    for j in range(2,int(i**0.5)+1):
        if i%j==0:
            k+=1
            break
    if k==0:
        print(i)