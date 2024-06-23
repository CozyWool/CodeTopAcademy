#include <iostream>
#include <cstdlib>
using namespace std;


class Stack
{
    int* arr;
    int top;
    int capacity;

public:
    Stack(int size);         
    ~Stack();                       

    void push(int);
    int pop();
    int peek();

    int size();
    bool isEmpty();
    bool isFull();
};

