.PHONY: restore build test run clean

SOLUTION = Lab7/Lab7.sln
MAIN_PROJECT = Lab7/Lab7.csproj

restore:
	dotnet restore $(SOLUTION)

build: restore
	dotnet build $(SOLUTION) --configuration Debug --no-restore

test: build
	dotnet test $(SOLUTION) --configuration Debug --no-build --verbosity normal

run: build
	dotnet run --project $(MAIN_PROJECT)

clean:
	dotnet clean $(SOLUTION)