FROM microsoft/aspnet:1.0.0-rc1-update1-coreclr

ADD . /source

WORKDIR /source

RUN bash build.sh

WORKDIR /source/src/Truewheelers

ENTRYPOINT ["dnx","web"]