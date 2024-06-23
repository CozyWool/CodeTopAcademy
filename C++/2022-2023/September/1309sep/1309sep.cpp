#include <iostream>
#include <algorithm>

using namespace std;

string first(string str, int index)
{
    str[index - 1] = '\0';
    return str;
}
string second(string str, char ch)
{
    for (auto& s : str)
    {
        if (s == ch)
        {
            s = '\0';
        }
    }
    return str;
}
string third(string str, char ch, int pos)
{
    str.insert(pos - 1, 1, ch);
    return str;
}
string fourth(string str)
{
    for (auto &s : str)
    {
        if (s == '.')
        {
            s = '!';
        }
    }
    return str;
}
int fifth(string str, char ch)
{
    return count(str.begin(), str.end(), ch);
}
void sixth()
{
    string str;
    cout << "Enter the sentence:";
    cin >> str;
    int digit = count_if(str.begin(), str.end(), isdigit);
    int alpha = count_if(str.begin(), str.end(), isalpha);
    int other = str.length() - (digit + alpha);
    cout << "Letters:" << alpha << "\nDigits:" << digit << "\nOther:" << other << endl;
}
int main()
{
   /* cout << "First:" << first("Hello world", 4) << endl;
    cout << "Second:" << second("Hello world", 'l') << endl;
    cout << "Third:" << third("Hello world", 'F', 3) << endl;
    cout << "Fourth:" << fourth("Hello world.AAA.") << endl;
    cout << "Fifth:" << fifth("Hello world.AAA.",'A') << endl;
    cout << "Sixth:" << endl;
    sixth();*/
    
    int i, j;
    
    int m1 = 5, m2 = 4;

    int** ptrarr = new int* [m1];
    for (int i = 0; i < m1; i++)
    {
        ptrarr[i] = new int[m2];
    }

    ptrarr[3][3] = 100;
    
    cout << ptrarr[3][3] << endl;
    delete[] ptrarr;
}