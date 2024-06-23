#pragma once
#include <iostream>
using namespace std;
class Calc
{
private:
    int age = 10;
public:
    int BirthdayCalc()
    {
        age += 1;
        return age;
    }
    template <typename T>
	T Calculate(T *arr, int size, char op)
	{
        T result = arr[0];
        switch (op)
        {
        case '+':
            for (int i = 1; i < size; i++)
                result += arr[i];
            return result;
            
        case '-':
            for (int i = 1; i < size; i++)
                result -= arr[i];
            return result;
          
        case '/':
            result = arr[0];
            for (int i = 1; i < size; i++)
                result /= arr[i];
            return result;
           
        case '*':
            for (int i = 1; i < size; i++)
                result *= arr[i];
            return result;
            
        default:
            return 0;
            
        }
	}
};