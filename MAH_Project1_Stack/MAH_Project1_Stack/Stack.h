#pragma once
#include <ostream>

template <class Type>
struct Node {
	Node(Type data, Node<Type>* next) 
		: data(data), next(next) {}
	Node* next;
	Type data;
};

template <class Type>
class Stack
{
public:

	Stack() : length(0), topNode(NULL) {
	}

	~Stack() {
		while (!isEmpty()) {
			pop();
		}
	}

	void push(Type data) {
		Node<Type>* newNode = new Node<Type>(data, topNode);
		topNode = newNode;
		++length;
	}

	Type pop() {
		if (!isEmpty()) {
			Node<Type>* popped = topNode;
			Type poppedData = popped->data;
			topNode = popped->next;
			--length;
			delete popped;
			return poppedData;
		}

		throw new std::exception("Stack underflow!");
	}

	bool isEmpty() {
		return length == 0;
	}

	void print() const {
		Node<Type>* tempTop = topNode;
		while (tempTop != NULL) {
			std::cout << tempTop->data << endl;
			tempTop = tempTop->next;
		}
	}

	int count() const {
		return length;
	}

private:
	Node<Type>*			topNode;
	int					length;

};


