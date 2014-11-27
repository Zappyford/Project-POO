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
	int* BuildMap(const int size, const int numberOfCellTypes);
};
// A ne pas implémenter dans le .h !
EXTERNC DLL MapBuilderC* MapBuilderC_new();
EXTERNC DLL void MapBuilderC_delete(MapBuilderC* algo);
EXTERNC DLL int* MapBuilderC_BuildMap(MapBuilderC* algo, const int size, const int numberOfCellTypes);


