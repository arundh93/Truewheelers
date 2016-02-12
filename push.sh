VERSION="0.0.1"

image=arundh93/arun-test-repo

vdo() {
    echo "+ $@"
    $@
}

if [ $? -eq 0 ]; then
    vdo docker tag -f $image:$VERSION $image:latest

    [ ! -z "$REGISTRY" ] && vdo docker push $image:$VERSION
    [ ! -z "$REGISTRY" ] && vdo docker push $image:latest

    
    rm -r output
    mkdir output
    echo "export IMAGE=$image" >> output/image_info.sh
    echo "export VERSION=$VERSION" >> output/image_info.sh

    exit $?
fi

>&2 echo "Faild to push docker image."
exit 1
