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
You don't want bin, obj and project.lock.json in your Docker image, remove them

./clean_up.sh

Then build the docker image

docker build -t burr/dotnethello .

docker images | grep burr

Test the docker image

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


### Blue/Green
oc new-build --binary --name=dotnethello-blue

oc start-build dotnethello-blue --from-dir=. --follow

oc new-app dotnethello-blue

oc patch route/dotnethello -p '{"spec": {"to": {"name": "dotnethello-blue" }}}'

### Canary

1) First create the non-canary service deployment

oc new-build --name dotnethello-first --binary -l app=dotnethello-first

oc start-build dotnethello-first --from-dir=. --follow

oc new-app dotnethello-first -l app=dotnethello-first

oc set probe dc/dotnethello-first --readiness --get-url=http://:5000/

oc expose service dotnethello-first

2) Then create the canary service deployment

vi Startup.cs

change the "Hello World" line

oc new-build --name dotnethello-first-canary --binary -l app=dotnethello-first-canary

oc start-build dotnethello-first-canary --from-dir=. --follow

oc new-app dotnethello-first-canary -l app=dotnethello-first-canary

oc set probe dc/dotnethello-first-canary --readiness --get-url=http://:5000/

oc patch dc/dotnethello-first -p '{"spec":{"template":{"metadata":{"labels":{"svc":"canary-dotnethello-first"}}}}}'

oc patch dc/dotnethello-first-canary -p '{"spec":{"template":{"metadata":{"labels":{"svc":"canary-dotnethello-first"}}}}}'

oc patch svc/dotnethello-first -p '{"spec":{"selector":{"svc":"canary-dotnethello-first","app": null, "deploymentconfig": null}, "sessionAffinity":"ClientIP"}}'

After that use the OpenShift console to "Up" and "Down" to get the mix right

http://screencast.com/t/dWdMETCtnYz





