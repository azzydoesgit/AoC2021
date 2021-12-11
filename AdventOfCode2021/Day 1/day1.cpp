#include <iostream>
#include <fstream>
#include <string>
#include <vector>
// why tf do I have to press shift for ctrl+v. lotta colors at least
// I have no idea what I'm doing. I'm dropping out of college, I truthfully don't enjoy it except for when I'm solving problems. Well, I've got a lot of problems now.

using namespace std;

int main() {
	fstream txtinput;
	string line;
	int largerThan = 0;

	txtinput.open("input");//no clue if this will work
	
	vector<int> values;

	while(getline(txtinput, line)){
		values.push_back(stoi(line));
	}
	// Turns the input document into a vector of integer values

	for (int i = 1; i < values.size(); i++){
		if (values.at(i) > values.at(i - 1)) largerThan++;
	}
	
	cout << largerThan << endl;
}