FROM registry.access.redhat.com/dotnet/dotnetcore-11-rhel7

ADD bin/Release/netcoreapp1.0/publish/. /opt/app-root/src/

WORKDIR /opt/app-root/src/

EXPOSE 5000 

CMD ["/bin/bash", "-c", "/opt/rh/rh-dotnetcore11/root/usr/bin/dotnet dotnet_docker_msa.dll"]
