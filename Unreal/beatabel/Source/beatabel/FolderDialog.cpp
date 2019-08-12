// No copyright

#include "FolderDialog.h"

// Sets default values
AFolderDialog::AFolderDialog()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AFolderDialog::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AFolderDialog::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void AFolderDialog::OpenDirectoryDialog(const FString& DialogTitle, const FString& DefaultPath, FString& OutFolderName)
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
				//Opening the folder picker
				DesktopPlatform->OpenDirectoryDialog(ParentWindowHandle, DialogTitle, DefaultPath, OutFolderName);
			}
		}
	}
}

void AFolderDialog::OpenCustomDirectoryDialog(const FString& FullPath, TArray<FString>& ChildrenFolders, FString& PathTillHere)
{
	// When at root, check what drive letters exist
	if (FullPath.Equals(TEXT("#")))
	{
		FString f;
		int asc = 65;
		FString a = TEXT("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
		FString p;
		IPlatformFile& PlatformFile = FPlatformFileManager::Get().GetPlatformFile();
		for (int i = 0; i < a.Len(); i++)
		{
			p = a.Mid(i, 1).Append(TEXT(":"));
			if (PlatformFile.DirectoryExists(*p))
			{
				ChildrenFolders.Add(*p);
			}
		}

	}

	// Otherwise do normal children exist check
	else
	{
		IFileManager& FileManager = IFileManager::Get();
		FString FinalPath = FullPath / TEXT("*");
		PathTillHere = FullPath;
		FileManager.FindFiles(ChildrenFolders, *FinalPath, false, true);
	}
}