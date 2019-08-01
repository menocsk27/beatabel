// No copyright

#pragma once

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
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
