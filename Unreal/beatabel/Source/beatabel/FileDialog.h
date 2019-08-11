// No copyright

#pragma once

#include "DesktopPlatform/Public/IDesktopPlatform.h"
#include "DesktopPlatform/Public/DesktopPlatformModule.h"

#include "Runtime/Core/Public/Misc/FileHelper.h"


#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "FileDialog.generated.h"

UCLASS()
class BEATABEL_API AFileDialog : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AFileDialog();
	

protected:
	UFUNCTION(BlueprintCallable, Category = "FilePicker")
		static void OpenFileDialog(const FString& DialogTitle, const FString& DefaultPath, const FString& DefaultFile, const FString& FileTypes, TArray<FString>& OutFileNames);
	
	UFUNCTION(BlueprintCallable, Category = "FilePicker")
		static void LoadFileToArray(const FString& FilePath, TArray<uint8>& rawFile);

	UFUNCTION(BlueprintCallable, Category = "FilePicker")
		static void SaveArrayToFile(const TArray<uint8>& rawFile, const FString& FilePath);
	
	
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
