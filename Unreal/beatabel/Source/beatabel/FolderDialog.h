// No copyright

#pragma once

#include "DesktopPlatform/Public/IDesktopPlatform.h"
#include "DesktopPlatform/Public/DesktopPlatformModule.h"
#include "Runtime/Core/Public/HAL/PlatformFilemanager.h"
#include "Runtime/Core/Public/HAL/FileManager.h"

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "FolderDialog.generated.h"


UCLASS()
class BEATABEL_API AFolderDialog : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AFolderDialog();

protected:
	UFUNCTION(BlueprintCallable, Category = "FilePicker")
		static void OpenDirectoryDialog(const FString& DialogTitle, const FString& DefaultPath, FString& OutFolderName);
	
	UFUNCTION(BlueprintCallable, Category = "FilePicker")
		static void OpenCustomDirectoryDialog(const FString& FullPath, TArray<FString>& ChildrenFolders, FString& PathTillHere, const bool& FolderOrFiles);
	
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
