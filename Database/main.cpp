#include <iostream>
#include <fstream>
#include <map>
#include <utility>
#include <sstream>
#include <regex>

#include "asteroid.h"
#include "asteroiddatabase.h"

using namespace std;

static const char* filename = "mpcorb.dat";
static const char* jsonFilename = "mpcorb.dat.json";

int main()
{
    AsteroidDatabase db;
    Filter filter{Filter::Magnitude, Filter::LESSER, 10};

    db.loadFromJSON(jsonFilename);
//    db.loadPolicy(filter);
//    db.loadFromFile(filename);
    cout << "Created "<< db.size() << " asteroids." << endl;


    return 0;
}

