#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

int main() {
	fstream txtinput;
	string line;

	txtinput.open("input");
	vector<int> values;

	while(getline(txtinput, line)){
		values.push_back(stoi(line));
	}
	// Turns input.txt into a vector of int values

	int largerThan = 0;

	for (int i = 0; i < values.size() - 3; i++){
		if ((values.at(i) + values.at(i + 1) + values.at(i + 2)) < (values.at(i + 1) + values.at(i + 2) + values.at(i + 3))){
			largerThan++;
		}
		//This monstrosity compares the sum of value i and the two after to the value i+1 and the two after that
	}

	cout << largerThan << endl;
}