#pragma once

#include <ostream>

namespace detail {
	template <class Type> struct Node {
		Node* next;
		Type data;

		Node(const Type& data, Node<Type>* next)
			: data(data), next(next) {}

	};
}

using namespace detail;

template<class Type> class Stack {
public:

	Stack()
		: length(0), topNode(NULL) {}

	~Stack() {
		Node<Type>* tempTop = topNode;
		while (tempTop != NULL) {
			tempTop = topNode->next;
			delete topNode;
			topNode = tempTop;
		}
	}

	Stack(const Stack&) = delete;

	Stack& operator=(const Stack&) = delete;

	void push(const Type& data) {
		Node<Type>* newNode = new Node<Type>(data, topNode);
		topNode = newNode;
		++length;
	}

	const Type& pop() {
		if (!isEmpty()) {
			Node<Type>* popped = topNode;
			Type poppedData = popped->data;
			topNode = popped->next;
			--length;
			delete popped;
			return poppedData;
		}

		throw std::exception("Stack underflow!");
	}

	bool isEmpty() const {
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


