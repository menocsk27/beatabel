// No copyright

#pragma once

#include "Runtime/ImageWrapper/Public/IImageWrapper.h"
#include "Runtime/ImageWrapper/Public/IImageWrapperModule.h"
#include "Runtime/Core/Public/HAL/FileManagerGeneric.h"
#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "MapArrayPopulator.generated.h"

UCLASS()
class BEATABEL_API AMapArrayPopulator : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AMapArrayPopulator();

protected:
	UFUNCTION(BlueprintCallable)
		static void FindFiles(const FString& Directory, const FString& FileExtension, TArray<FString>& FoundFiles);
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
