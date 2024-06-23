a=input()
if '+' in a:
    b,c=a.split('+')
    print(int(b)+int(c))
if '-' in a:
    b,c=a.split('-')
    print(int(b)-int(c))
if '*' in a:
    b,c=a.split('*')
    print(int(b)*int(c))
if '/' in a:
    b,c=a.split('/')
    print(int(b)/int(c))
