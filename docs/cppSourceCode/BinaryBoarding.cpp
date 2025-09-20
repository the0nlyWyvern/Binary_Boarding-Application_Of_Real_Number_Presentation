#include <cmath>
#include <fstream>
#include <iostream>
#include <string>

using namespace std;

class BoardingPass {
   private:
    string _code;
    bool _IsFirstClass;
    int _row;
    int _col;
    double _id;

    void FindClass();
    void FindRow();
    void FindColumn();
    void FindId();

   public:
    BoardingPass(string& code);
    double GetId();
};

void PrintSeatId(string);

int main() {
    // Question 1
    cout << "Question 1\n";
    PrintSeatId("0RRRBFFFBBF");
    PrintSeatId("1RRRFFFBBBF");
    PrintSeatId("0RLLBBFFBBF");
    PrintSeatId("0RLRBFBFFFF");

    // ---
    // Question 2
    cout << "\nQuestion 2\n";

    string filePath = "2.txt";

    double greatestAbsId = -1;

    ifstream f(filePath);
    if (f.is_open()) {
        string line;
        while (getline(f, line)) {
            BoardingPass pass(line);
            greatestAbsId = max(greatestAbsId, abs(pass.GetId()));
        }
        f.close();
    } else {
        cout << "Cannot find the file " << filePath << endl;
        return -1;
    }

    cout << "Seat ID with the greatest absolute value: " << greatestAbsId
         << endl;

    return 0;
}

void PrintSeatId(string code) {
    BoardingPass seat(code);
    cout << "Seat ID for " << code << " = " << seat.GetId() << endl;  // 5.25
}

// class properties

BoardingPass::BoardingPass(string& code) : _code(code), _row(0), _col(0) {
    FindClass();
    FindRow();
    FindColumn();
    FindId();
}

double BoardingPass::GetId() { return _id; }

void BoardingPass::FindClass() {
    if (_code[0] == '1')
        _IsFirstClass = true;  // first class
    else
        _IsFirstClass = false;  // coach class
}

void BoardingPass::FindRow() {
    for (int i = _code.length() - 1; i >= 4; i--) {
        if (_code[i] == 'B') _row += (int)(pow(2, 10 - i));
    }
}

void BoardingPass::FindColumn() {
    for (int i = 3; i >= 0; i--) {
        if (_code[i] == 'R') _col += (int)(pow(2, 3 - i));
    }
}

void BoardingPass::FindId() {
    _id = ((double)_row / 256 + 1) * pow(2, _col - 3);

    if (_IsFirstClass) _id *= -1;
}
