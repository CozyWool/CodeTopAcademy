#include "Stack.h"

Stack::Stack(int size)
{
    if (size < 0 || size > 10)
    {
        throw invalid_argument("����������� ����� ������ ���� ������������� � �� ����� ��������� 10");
    }
    arr = new int[size];
    capacity = size;
    top = -1;
}

Stack::~Stack() 
{
    delete[] arr;
}

void Stack::push(int x)
{
    if (isFull())
    {
        throw overflow_error("���� ����������");
    }

    arr[++top] = x;
}

int Stack::pop()
{
    if (isEmpty())
    {
        throw underflow_error("���� ����");
    }

    return arr[top--];
}

int Stack::peek()
{
    if (!isEmpty()) 
    {
        throw underflow_error("���� ����");
    }
    return arr[top];
}

int Stack::size() {
    return top + 1;
}

bool Stack::isEmpty() {
    return top == -1;
}

bool Stack::isFull() {
    return top == capacity - 1;
}