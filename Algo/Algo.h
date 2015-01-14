#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
class DLL MapBuilderC {

public:
	MapBuilderC() {}
	~MapBuilderC() {}

	void placePlayer1(const int sizeOfMap, int &x, int &y) const;
	void placePlayer2(const int sizeOfMap, int &x, int &y) const;
	int* BuildMap(const int size, const int numberOfCellTypes) const;

};


// A ne pas implémenter dans le .h !
EXTERNC DLL MapBuilderC* MapBuilderC_new();
EXTERNC DLL void MapBuilderC_delete(MapBuilderC* algo);
EXTERNC DLL int* MapBuilderC_BuildMap(MapBuilderC* algo, const int size, const int numberOfCellTypes);
EXTERNC DLL void placePlayer1(const int sizeOfMap, int &x, int &y);
EXTERNC DLL void placePlayer2(const int sizeOfMap, int &x, int &y);


