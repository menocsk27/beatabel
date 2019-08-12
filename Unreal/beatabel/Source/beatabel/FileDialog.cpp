// No copyright


#include "FileDialog.h"

// Sets default values
AFileDialog::AFileDialog()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AFileDialog::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AFileDialog::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void AFileDialog::OpenFileDialog(const FString& DialogTitle, const FString& DefaultPath, const FString& DefaultFile, const FString& FileTypes, TArray<FString>& OutFileNames)
{
	if (GEngine)
	{
		if (GEngine->GameViewport)
		{
			// Set parent window as the viewport
			void* ParentWindowHandle = GEngine->GameViewport->GetWindow()->GetNativeWindow()->GetOSWindowHandle();
			IDesktopPlatform* DesktopPlatform = FDesktopPlatformModule::Get();
			if (DesktopPlatform)
			{
				//Opening the file picker
				uint32 SelectionFlag = 0; //A value of 0 represents single file selection while a value of 1 represents multiple file selection
				DesktopPlatform->OpenFileDialog(ParentWindowHandle, DialogTitle, DefaultPath, FString(""), FileTypes, SelectionFlag, OutFileNames);
			}
		}
	}
}

void AFileDialog::LoadFileToArray(const FString& FilePath, TArray<uint8>& rawFile)
{
	//* If true the song was successfully loaded
	bool loaded = false;
	//* rawFile is loaded song file (binary, encoded)
	FFileHelper::LoadFileToArray(rawFile, *FilePath);
	
}

void AFileDialog::SaveArrayToFile(const TArray<uint8>& rawFile, const FString& FilePath)
{
	FFileHelper::SaveArrayToFile(rawFile, *FilePath);
}

void AFileDialog::DeleteFile(const FString& FilePath)
{
	FPlatformFileManager::Get().GetPlatformFile().DeleteFile(*FilePath);
}

