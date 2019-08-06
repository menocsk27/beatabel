// No copyright

#include "MapArrayPopulator.h"
using namespace std;
// Sets default values
AMapArrayPopulator::AMapArrayPopulator()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AMapArrayPopulator::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AMapArrayPopulator::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void AMapArrayPopulator::FindFiles(const FString& Directory, const FString& FileExtension, TArray<FString>& FoundFiles)
{
	IFileManager& FileManager = IFileManager::Get();
	FileManager.FindFiles(FoundFiles, *Directory, *FileExtension);
	//IImageWrapperModule& ImageWrapperModule = FModuleManager::Load
}
