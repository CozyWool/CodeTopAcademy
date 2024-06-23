word=input()
vowels=0
consonants=0
for i in word:
    if i=='a' or i=='e' or i=='i' or i=='o' or i=='u':
        vowels+=1
    else:
        consonants+=1
if vowels > consonants:
    print('Yes')
else:
    print('No')