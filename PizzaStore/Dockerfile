FROM bitnami/dotnet-sdk:7

COPY . /app

ENV PORT=5030

CMD ["dotnet","run","--urls","http://localhost:{PORT}"]