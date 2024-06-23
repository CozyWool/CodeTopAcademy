#include <iostream>
#include <vector>

using namespace std;

int main()
{
    int n, k, s;
    cin >> n >> k >> s;
    vector<long long> a(n), pr(n + 1, 0);
    for (int i = 0; i < n; ++i)
        cin >> a[i];
    for (int i = 0; i < n; ++i)
        pr[i + 1] = pr[i] + a[i];

    long long mnInd = 0, sm = 0;

    for (int i = 1; i <= n; ++i)
    {
        long long tracks = ((i - mnInd + k - 1) / k) * s;
        if (pr[i] - pr[mnInd] - tracks > sm)
            sm = pr[i] - pr[mnInd] - tracks;
        if (pr[i] <= pr[mnInd])
            mnInd = i;
    }

    cout << sm;
}