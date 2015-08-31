#include <iostream>
#include "Stack.h"

using namespace std;

int main() {
	Stack<int> myStack;

	// Push some values
	myStack.push(2);
	myStack.push(4);
	myStack.push(8);
	myStack.push(16);
	myStack.push(32);

	// We pop the 32
	myStack.pop(); 

	// Display count after the pop
	int lastPopped = myStack.pop();
	cout << "Popped value: " << lastPopped << ", Count: " << myStack.count() << endl; 

	// Print whole stack
	cout << endl << "Stack print: " << endl;
	myStack.print(); 

	// Exit program when the 'any' key is pressed.
	system("PAUSE");
	return 0;
}