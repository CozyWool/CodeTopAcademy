#include <iostream>
#include <math.h>
using namespace std;

double g(double a, double b)
{
    return (pow(a, 2) - pow(b, 2) / 2 * a * b - a - b) + (a + b) * sqrt(fabs(a + b) / 2);
}
int main()
{
    double s, t;
    cin >> s >> t;
    cout << g(1.2, s) + g(t, s) - g(2 * s - 1, s * t) << endl;
}
