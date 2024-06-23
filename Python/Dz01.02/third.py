s=input().split()
d={}
for i in s:
    s,b=i.split('=')
    d[s]=b
if d.get('house')!=None and d.get('5')!=None and d.get('True')!=None:
    print('ДА')
else:
    print('НЕТ')