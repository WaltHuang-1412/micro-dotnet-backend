# 使用 .NET 9 SDK 作為構建環境
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# 複製專案文件
COPY ["src/MicroDotnetBackend/MicroDotnetBackend.csproj", "src/MicroDotnetBackend/"]
RUN dotnet restore "src/MicroDotnetBackend/MicroDotnetBackend.csproj"

# 複製其餘文件
COPY . .
WORKDIR "/src/src/MicroDotnetBackend"
RUN dotnet build "MicroDotnetBackend.csproj" -c Release -o /app/build

# 發布
FROM build AS publish
RUN dotnet publish "MicroDotnetBackend.csproj" -c Release -o /app/publish

# 運行環境
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "MicroDotnetBackend.dll"] 