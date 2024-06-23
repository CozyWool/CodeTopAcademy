#include <iostream>

struct TreeNode
{
	int val;
	TreeNode* left;
	TreeNode* right;
	TreeNode() : val(0), left(nullptr), right(nullptr) {}
	TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
	TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
};

class Solution
{
public:
	TreeNode* result;
	bool checkTree(TreeNode* root)
	{
		return root->left->val + root->right->val == root->val;
	}
	int rangeSumBST(TreeNode* root, int low, int high)
	{
		if (root == nullptr)
		{
			return 0;
		}
		int rangeSum = root->val >= low && root->val <= high ? root->val : 0;
		if (root->left != nullptr)
		{
			rangeSum += rangeSumBST(root->left, low, high);
		}
		if (root->right != nullptr)
		{
			rangeSum += rangeSumBST(root->right, low, high);
		}
		return rangeSum;
	}

	TreeNode* getTargetCopy(TreeNode* original, TreeNode* cloned, TreeNode* target)
	{
		searchTargetRecursive(cloned, target->val);
		return result;
	}

	int countRecursive(TreeNode* node)
	{
		return node == nullptr ? 0 : 1 + countRecursive(node->left) + countRecursive(node->right);
	}

	int heightRecursive(TreeNode* node) 
	{
		if (!node)
		{
			return 0;
		}

		int leftHeight = heightRecursive(node->left);
		int rightHeight = heightRecursive(node->right);
		return std::max(leftHeight, rightHeight) + 1;
	}
	
	int sum = 0;

	int deepestLeavesSum(TreeNode* root)
	{
		int rootHeight = heightRecursive(root);
		sumDeepestLeavesRecursive(root, 1, rootHeight);
		return sum;
	}

	void sumDeepestLeavesRecursive(TreeNode* node, int nodeHeight, int targetHeight)
	{
		if (!node)
		{
			return;
		}

		if (nodeHeight == targetHeight)
		{
			sum += node->val;
			return;
		}
		sumDeepestLeavesRecursive(node->left, nodeHeight + 1, targetHeight);
		sumDeepestLeavesRecursive(node->right, nodeHeight + 1,targetHeight);
	}

	void searchTargetRecursive(TreeNode* node, int value)
	{
		if (!node)
		{
			return;
		}

		if (node->val == value)
		{
			result = node;
			return;
		}
		searchTargetRecursive(node->left, value);
		searchTargetRecursive(node->right, value);
	}
};


class Node
{
public:
	int value;
	Node* left;
	Node* right;
	Node(int value)
	{
		this->value = value;
		left = nullptr;
		right = nullptr;
	}
};

class BinarySearchTree
{
private:
	Node* root;

	BinarySearchTree()
	{
		root = nullptr;
	}

	Node* insertRecursive(Node* node, int value)
	{
		if (!node)
		{
			return new Node(value);
		}

		if (value > node->value)
		{
			node->right = insertRecursive(node->right, value);
		}
		else if (value < node->value)
		{
			node->left = insertRecursive(node->left, value);
		}
		return node;
	}

	bool isBalanced(Node* node)
	{
		int leftNode = countRecursive(node->left);
		int rightNode = countRecursive(node->right);
		return abs(leftNode - rightNode) < 1;
	}

	int countRecursive(Node* node)
	{
		return node == nullptr ? 0 : 1 + countRecursive(node->left) + countRecursive(node->right);
	}
};