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

