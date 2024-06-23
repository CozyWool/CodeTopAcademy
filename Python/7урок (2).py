f=open('Students.txt','a+',encoding='utf')
f.write('Hello\n')
s=f.readlines()
print(s)