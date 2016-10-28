## Use with CDK 
http://developers.redhat.com/products/cdk/overview/

vagrant ssh

cd /vagrant

### dotnet core hello world
Installing dotnet on RHEL
https://access.redhat.com/documentation/en/net-core/1.0/getting-started-guide/chapter-1-install-net-core-100-on-red-hat-enterprise-linux

dotnet restore

dotnet run

Browser http://10.1.2.2:5000

### docker
rm -rf bin

rm -rf obj

rm -rf project.lock.json

docker build -t burr/dotnethello .

docker images | grep burr

docker run -d -p 5000:5000 burr/dotnethello

docker ps | grep burr

docker stop <containerid>

docker rm <containerid>

### openshift/kubernetes
oc login 10.1.2.2:8443

user: openshift-dev

devel

oc new-project mydotnet

oc new-build --binary --name=dotnethello

oc start-build dotnethello --from-dir=. --follow

oc new-app dotnethello

oc expose service dotnethello

oc patch dc/dotnethello -p '{"spec":{"template":{"spec":{"containers":[{"name":"dotnethello","readinessProbe":{"httpGet":{"path":"/","port":5000}}}]}}}}'

### blue/green




