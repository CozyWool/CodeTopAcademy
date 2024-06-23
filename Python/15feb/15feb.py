try:
    f=open('text.txt','r')
    s=f.read().split()
    f.close()
    w=open('textt.txt','w')
    b=[]
    for i in range(33,64):
        b.append(chr(i))
    sm=0
    cnt=0
    for i in s:
        if len(i)%2==0 and len(i)%3!=0 and len(i)>2 and not i[-1] in b:
            w.write(i+'\n')
            cnt+=1
            sm+=len(i)
    w.write('Кол-во букв:'+str(sm))
    w.write('\nКол-во слов:'+str(cnt))
    w.close()
except:
    print('smth wrong')
