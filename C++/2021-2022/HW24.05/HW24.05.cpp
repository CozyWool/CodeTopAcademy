#include <iostream>
#include "Time.h"
using namespace std;
int pastTime(Time t1, Time t2) 
{
    return t1.getTimeInSeconds(); -t2.getTimeInSeconds();
}
int main()
{
    Time* t = new Time[2];
    t[0].Set(15, 0, 30);
    t[1].Set(16, 0, 0);
    cout << pastTime(t[0], t[1]);
}
