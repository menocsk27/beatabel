// No copyright

#pragma once

#include "Runtime/Online/HTTP/Public/Http.h"
#include "Runtime/Core/Public/Misc/FileHelper.h"


#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "REST.generated.h"

UCLASS()
class BEATABEL_API AREST : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AREST();

protected:
	

	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
